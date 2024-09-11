#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

#endregion


    /// <summary>Standard CDict yapýsý.</summary>
[Serializable()]
public class CDict<TKey, TValue> : Dictionary<TKey, TValue> {
    #region Get/Set
    [TypeConverter( typeof( ExpandableObjectConverter ) )]
    public virtual TValue this[TKey key] {
        get {
            try { return base[key]; }
            catch (KeyNotFoundException e) { throw new KeyNotFoundException( string.Format( "[{0}] Anahtarý Dict'de BULUNAMADI!", key ), e ); }
        }       // Yoksa 'KeyNotFoundException' döner.
        set {
            if (base.ContainsKey( key ))
                base[key] = value;
            else
                base.Add( key, value );
        }
    }

    public virtual bool IsEmpty {
        get { return this.Count == 0; }
    }
    #endregion


    public CDict() { }

    public CDict( params KeyValuePair<TKey, TValue>[] keyValueArray ) {
        this.Add( keyValueArray );
    }

    public CDict( IEnumerable<TKey> keys, IEnumerable<TValue> values ) {
        this.AddRange( keys, values );
    }

    public CDict( IDictionary<TKey, TValue> dict ) {
        this.AddRange( dict );
    }

    public TValue Add( TKey key, TValue value ) {
        this[key] = value;

        return value;
    }

    public void Add( params KeyValuePair<TKey, TValue>[] keyValueArray ) {
        foreach (var keyValuePair in keyValueArray)
            this.Add( keyValuePair.Key, keyValuePair.Value );
    }

    public CDict<TKey, TValue> AddRange( IEnumerable<TKey> _keys, IEnumerable<TValue> _values ) {
        var keys = new CList<TKey>( _keys );
        var values = new CList<TValue>( _values );
        if (keys != null && values != null && keys.Count == values.Count) {
            for (int i = 0; i < keys.Count; i++) {
                this.Add(
                    new KeyValuePair<TKey, TValue>(
                        keys[i], values[i] ) );
            }
        }
        return this;
    }

    public CDict<TKey, TValue> AddRange( IDictionary<TKey, TValue> dict ) {
        foreach (var kv in dict)
            Add( kv );

        return this;
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
        CDict<TKey, TValue>.Enumerator dictEnum = base.GetEnumerator();
        while (dictEnum.MoveNext())
            yield return dictEnum.Current;
    }

    //public CDict<TKey, TValue> forEach<TKey2, TValue2>( FuncV<TKey2, TValue2> funcPtr )
    //{
    //    foreach ( var kv in this )
    //        funcPtr( kv.get<TKey2>( "Key" ), kv.get<TValue2>( "Value" ) );
    //    return this;
    //}

    //public CDict<TKey, TValue> forEach( FuncV<TKey, TValue> funcPtr )
    //{
    //    return forEach<TKey, TValue>( funcPtr );
    //}

    ///<summary>Verilen dictteki elemanlardan, bu dictten farklý deðeri olan elemanlar alýnýr ve yeni dict dönülür.</summary>
    public CDict<TKey, TValue> farklariBul( IDictionary<TKey, TValue> orjDict ) {
        var sonuc = new CDict<TKey, TValue>();
        foreach (var kv in this) {
            if (orjDict.ContainsKey( kv.Key ) && !Equals( orjDict[kv.Key], kv.Value ))
                sonuc.Add( kv );
        }

        return sonuc;
    }

    public override string ToString() {
        var itemListString = "";

        foreach (var kv in this) {
            #region #foreach block#
            itemListString += string.Format( "{0}={1}\r\n  "
                                    , kv.Key
                                    , ( Equals( kv.Value, default( TValue ) ) ? "null" : ( kv.Value ).ToString() ) );
            #endregion
        }

        return itemListString;


        /*
        return String.Format(
            "{{{0}}}\n     Count: {1}\n     KeyType: {{{2}}}, ValueType: {{{3}}}\n     Items:\n{4}"
            , this.GetType().ToString()
            , this.Count
            , typeof(TKey).ToString()
            , typeof(TValue).ToString()
            , itemListString
            );
         */
    }
}
