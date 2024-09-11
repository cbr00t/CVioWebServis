using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Text;
using System.IO;
using System.Reflection;

namespace CVioWebServis {
    public static class CWSExtension {
        #region WS Tools
        public static TValue atPut<TKey, TValue>( this IDictionary<TKey, TValue> self, TKey key, TValue value ) {
            if (self.ContainsKey( key ))
                self[key] = value;
            else
                self.Add( key, value );

            return value;
        }

        public static TValue atIfAbsent<TKey, TValue>( this IDictionary<TKey, TValue> self, TKey key, Func<TValue> absentBlock = null ) {
            if (self.ContainsKey( key ))
                return self[key];

            return ( absentBlock == null ? default( TValue ) : absentBlock() );
        }

        public static TValue atIfAbsentPut<TKey, TValue>( this IDictionary<TKey, TValue> self, TKey key, Func<TValue> absentBlock = null ) {
            TValue value;

            if (self.ContainsKey( key ))
                return self[key];

            self.Add( key, ( value = absentBlock == null ? default( TValue ) : absentBlock() ) );
            return value;
        }

        public static TValue bosDegilseAtPut<TKey, TValue>( this IDictionary<TKey, TValue> self, TKey key, TValue value ) {
            if (value.bosmu())
                return default( TValue );

            return self.atPut( key, value );
        }

        public static IDictionary<string, object> asEkArgs<T>( this T[][] self ) {
            CDict<string, object> result;

            result = new CDict<string, object>();
            foreach (var ekArgKV in self)
                result.atPut( ekArgKV[0].ToString(), ekArgKV[1] );

            return result;
        }
        #endregion

        #region Genel
        public static bool bosmu( this object self ) {
            if (self == null || self is DBNull)
                return true;

            if (self is string)
                return string.IsNullOrEmpty( (string)self );

            if (self is TimeSpan)
                return ( (TimeSpan)self ) == TimeSpan.Zero;
            if ( self is DateTime)
                return ( (DateTime)self ) == DateTime.MinValue;
            if (self is TimeSpan?)
                return !( (TimeSpan?)self ).HasValue || ( (TimeSpan?)self ).Value == TimeSpan.Zero;
            if (self is DateTime?)
                return !( (DateTime?)self ).HasValue || ( (DateTime?)self ).Value == DateTime.MinValue;

            if (( self is ICollection && ( (ICollection)self ).Count == 0 )
                    || ( self is IDictionary && ( (IDictionary)self ).Count == 0 )) {
                return true;
            }

            if (( self is double && ( (double)self ) == 0d )
                    || ( self is float && ( (float)self ) == 0f )
                    || ( self is decimal && ( (decimal)self ) == 0M )
                    || ( self is short && ( (short)self ) == 0 )
                    || ( self is ushort && ( (ushort)self ) == 0 )
                    || ( self is int && ( (int)self ) == 0 )
                    || ( self is uint && ( (uint)self ) == 0 )
                    || ( self is long && ( (long)self ) == 0L )
                    || ( self is ulong && ( (ulong)self ) == 0L )
                    || ( self is byte && ( (byte)self ) == 0 )
                    || ( self is sbyte && ( (sbyte)self ) == 0 )
                ) {
                return true;
            }

            // hizli kontrol icin
            if (       ( self is string[] && ( (string[])self ).Length == 0 )
                    || ( self is char[] && ( (char[])self ).Length == 0 )
                    || ( self is byte[] && ( (byte[])self ).Length == 0 )
                    || ( self is int[] && ( (int[])self ).Length == 0 )
                    || ( self is uint[] && ( (uint[])self ).Length == 0 )
                    || ( self is long[] && ( (long[])self ).Length == 0 )
                    || ( self is ulong[] && ( (ulong[])self ).Length == 0 )
                    || ( self is short[] && ( (short[])self ).Length == 0 )
                    || ( self is ushort[] && ( (ushort[])self ).Length == 0 )
                    || ( self is double[] && ( (double[])self ).Length == 0 )
                    || ( self is float[] && ( (float[])self ).Length == 0 )
                    || ( self is decimal[] && ( (decimal[])self ).Length == 0 )
                    || ( self is DateTime[] && ( (DateTime[])self ).Length == 0 )
                    || ( self is TimeSpan[] && ( (TimeSpan[])self ).Length == 0 )
                    || ( self is Type[] && ( (Type[])self ).Length == 0 )
                    || ( self is object[] && ( (object[])self ).Length == 0 )
                    || ( self is Filtre[] && ( (Filtre[])self ).Length == 0 )
            ) {
                return true;
            }

            if (self is Array)
                return ( (Array)self ).Length == 0;
            
            if (self is IEnumerable) {
                IEnumerator enm;

                enm = ( (IEnumerable)self ).GetEnumerator();
                if (!enm.MoveNext())
                    return true;
            }

            return false;
        }

        public static bool bosDegilmi( this object self ) {
            return !self.bosmu();
        }

        public static T coalesce<T>( this T self, Func<T> absentBlock ) {
            if (self.isNull())
                return absentBlock == null ? default( T ) : absentBlock();

            return self;
        }

        public static T coalesce<T>( this T self, T absentValue ) {
            return self.coalesce( () => absentValue );
        }

        public static T emptyCoalesce<T>( this T self, Func<T> absentBlock ) {
            if (self.bosmu())
                return absentBlock == null ? default( T ) : absentBlock();

            return self;
        }

        public static T emptyCoalesce<T>( this T self, T absentValue ) {
            return self.emptyCoalesce( () => absentValue );
        }

        public static bool isNull( this object self ) {
            return self == null || self is DBNull;
        }

        public static bool isNumber( this object self ) {
            return self is double || self is float || self is decimal ||
                    self is short || self is ushort || self is byte || self is sbyte ||
                    self is int || self is uint || self is long || self is ulong;
        }

        public static byte[] asBuffer( this object self ) {
            if (self is byte[])
                return (byte[])self;
            if (self is string)
                return CGlobals.DefaultEncoding.GetBytes( (string)self );
            if (self is char[])
                return ( (char[])self ).asString().asBuffer();
            if (self is MemoryStream)
                return ( (MemoryStream)self ).ToArray();
            if (self is StringBuilder)
                return ( (StringBuilder)self ).asString().asBuffer();
            if (self is StreamReader)
                return ( (StreamReader)self ).asString().asBuffer();

            return null;
        }

        public static string asString( this object self ) {
            if (self.isNull())
                return string.Empty;
            if (self is string)
                return (string)self;
            if (self is byte[])
                return CGlobals.DefaultEncoding.GetString( (byte[])self );
            if (self is char[])
                return new string( (char[])self );
            if (self is DateTime) {
                DateTime _self;

                _self = (DateTime)self;
                return _self.TimeOfDay.bosmu() ? _self.asDateGosterimString() : _self.asGosterimString();
            }
            /*if (( self is double && ( (double)self ) == 0d )
                    || ( self is float && ( (float)self ) == 0f )
                    || ( self is decimal && ( (decimal)self ) == 0M )
                    || ( self is short && ( (short)self ) == 0 )
                    || ( self is int && ( (int)self ) == 0 )
                    || ( self is long && ( (long)self ) == 0L )
                ) {
                    return self.ToString();
            }*/
            if (self is Enum)
                return ( (Enum)self ).ToString();
            if (self is StringBuilder)
                return ( (StringBuilder)self ).ToString();
            if (self is StreamReader)
                return ( (StreamReader)self ).ReadToEnd();
            if (self is MemoryStream)
                return ( (MemoryStream)self ).asBuffer().asString();

            return self.ToString();
        }

        public static bool asBool( this object self ) {
            if (self.bosmu())
                return false;

            if (self is string) {
                string _self;

                _self = ( (string)self ).ToUpper().Trim();
                if (_self == "H" || self == "FALSE")
                    return false;
            }

            return true;
        }

        public static string fileStr( this bool self ) {
            return self ? "*" : "";
        }

        public static DateTime? asDateTimeQ( this object self ) {
            if (self.bosmu())
                return null;

            if (self is DateTime)
                return (DateTime)self;
            if (self is DateTime?)
                return (DateTime?)self;

            try { return Convert.ToDateTime( self ); }
            catch (Exception) { return null; }
        }

        public static DateTime asDateTime( this object self ) {
            DateTime? value;

            value = self.asDateTimeQ();
            if (!value.HasValue)
                return DateTime.MinValue;

            return value.Value;
        }

        public static int? asIntegerQ( this object self ) {
            if (self.bosmu())
                return null;

            if (self is int)
                return (int)self;
            if (self is int?)
                return (int?)self;

            try { return Convert.ToInt32( self ); }
            catch (Exception) { return null; }
        }

        public static int asInteger( this object self ) {
            int? value;

            value = self.asIntegerQ();
            if (!value.HasValue)
                return 0;

            return value.Value;
        }

        public static decimal? asDecimalQ( this object self ) {
            if (self.bosmu())
                return null;

            if (self is decimal)
                return (decimal)self;
            if (self is decimal?)
                return (decimal?)self;

            try { return Convert.ToDecimal( self ); }
            catch (Exception) { return null; }
        }

        public static decimal asDecimal( this object self ) {
            decimal? value;

            value = self.asDecimalQ();
            if (!value.HasValue)
                return 0;

            return value.Value;
        }

        public static string asDotnetFileString( this DateTime self ) {
            if (self == DateTime.MinValue)
                return string.Empty;

            return self.ToString( CGlobals.DotnetFileString_DateTime );
        }

        public static string asDateDotnetFileString( this DateTime self ) {
            if (self == DateTime.MinValue)
                return string.Empty;

            return self.ToString( CGlobals.DotnetFileString_Date );
        }

        public static string asGosterimString( this DateTime self ) {
            if (self == DateTime.MinValue)
                return string.Empty;

            return self.ToString( CGlobals.GosterimString_DateTime );
        }

        public static string asDateGosterimString( this DateTime self ) {
            if (self == DateTime.MinValue)
                return string.Empty;

            return self.ToString( CGlobals.GosterimString_Date );
        }

        public static string asDotnetFileString( this DateTime? self ) {
            if (!self.HasValue)
                return string.Empty;

            return self.Value.asDotnetFileString();
        }

        public static string asDateDotnetFileString( this DateTime? self ) {
            if (!self.HasValue)
                return string.Empty;

            return self.Value.asDateDotnetFileString();
        }

        public static string asGosterimString( this DateTime? self ) {
            if (!self.HasValue)
                return string.Empty;

            return self.Value.asGosterimString();
        }

        public static string asDateGosterimString( this DateTime? self ) {
            if (!self.HasValue)
                return string.Empty;

            return self.Value.asDateGosterimString();
        }

        public static TDest aktar<TDest>( this TDest dest, object source ) {
            if (source.isNull())
                return dest;
            var clsThis = source.GetType();
            var clsDest = dest.GetType();
            foreach (var srcInfo in clsThis.GetFields( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance )) {
                #region block
                var destInfo = clsDest.GetField( srcInfo.Name );
                if (destInfo != null)
                    destInfo.SetValue( dest, srcInfo.GetValue( source ) );
                #endregion
            }
            foreach (var srcInfo in clsThis.GetProperties( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance )) {
                #region block
                if (srcInfo.GetGetMethod() == null)
                    continue;
                var destInfo = clsDest.GetProperty( srcInfo.Name );
                if (destInfo != null && destInfo.GetSetMethod() != null)
                    destInfo.SetValue( dest, srcInfo.GetValue( source, null ), null );
                #endregion
            }
            return dest;
        }
        public static TSource shallowCopy<TSource>( this TSource source ) where TSource : class, new() {
            if (source.isNull())
                return source;
            var clsThis = source.GetType();
            var dest = new TSource();
            foreach (var srcInfo in clsThis.GetFields( BindingFlags.Public | BindingFlags.NonPublic )) {
                #region block
                var destInfo = clsThis.GetField( srcInfo.Name );
                destInfo.SetValue( dest, srcInfo.GetValue( source ) );
                #endregion
            }
            foreach (var srcInfo in clsThis.GetProperties( BindingFlags.Public | BindingFlags.NonPublic )) {
                #region block
                var destInfo = clsThis.GetProperty( srcInfo.Name );
                destInfo.SetValue( dest, srcInfo.GetValue( source, null ), null );
                #endregion
            }
            return dest;
        }
        #endregion
    }
}