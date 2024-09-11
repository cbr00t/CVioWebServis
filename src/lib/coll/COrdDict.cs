#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

#endregion

[Serializable()]
/// <summary>Elemanlarý sýralý tutan CDict yapýsý.</summary>
public class COrdDict<TKey, TValue> : CDict<TKey, TValue> {
    CList<KeyValuePair<TKey, TValue>> keyValuePairList = new CList<KeyValuePair<TKey, TValue>>();

    #region Get/Set
    [TypeConverter( typeof( ExpandableObjectConverter ) )]
    public CList<KeyValuePair<TKey, TValue>> KeyValuePairList {
        get { return keyValuePairList; }
    }

    [TypeConverter( typeof( ExpandableObjectConverter ) )]
    public override bool IsEmpty { get { return KeyValuePairList.Count == 0; } }

    [TypeConverter( typeof( ExpandableObjectConverter ) )]
    public new int Count { get { return KeyValuePairList.Count; } }

    [TypeConverter( typeof( ExpandableObjectConverter ) )]
    public override TValue this[TKey key] {
        get {
            try { return AtIndex( IndexOfKey( key ) ); }
            catch (ArgumentOutOfRangeException aex) {
                throw new KeyNotFoundException(
                    string.Format( "'{0}' key i bulunamadý!", key.ToString() ), aex
                    );
            }
        }
        set { Add( key, value ); }
    }
    #endregion


    public COrdDict() { }

    public COrdDict( params object[][] keyValuePairArray ) {
        foreach (object[] keyValuePairBilgi in keyValuePairArray)
            this.Add( (TKey)keyValuePairBilgi[0], (TValue)keyValuePairBilgi[1] );
    }

    public COrdDict( params KeyValuePair<TKey, TValue>[] keyValueArray ) {
        this.AddRange( keyValueArray );
    }

    public COrdDict( CList<TKey> keys, CList<TValue> values ) {
        this.AddRange( keys, values );
    }

    public TValue Add( TKey key, TValue value ) {
        if (this.ContainsKey( key ))
            AtIndex( IndexOfKey( key ), value );
        else {
            this.KeyValuePairList.Add(
                new KeyValuePair<TKey, TValue>( key, value ) );
            base.Add( key, value );
        }
        return value;
    }

    public COrdDict<TKey, TValue> AddRange( IEnumerable<TKey> _keys, IEnumerable<TValue> _values ) {
        var keys = new CList<TKey>( _keys );
        var values = new CList<TValue>( _values );

        if (keys != null && values != null && keys.Count == values.Count) {
            for (int i = 0; i < keys.Count; i++) {
                this.AddRange(
                    new KeyValuePair<TKey, TValue>(
                        keys[i], values[i] ) );
            }
        }
        return this;
    }

    public COrdDict<TKey, TValue> AddRange( params KeyValuePair<TKey, TValue>[] keyValueArray ) {
        foreach (KeyValuePair<TKey, TValue> keyValuePair in keyValueArray)
            this.Add( keyValuePair.Key, keyValuePair.Value );
        return this;
    }

    public COrdDict<TKey, TValue> AddRange( IDictionary<TKey, TValue> dict ) {
        foreach (KeyValuePair<TKey, TValue> kv in dict)
            AddRange( kv );
        return this;
    }

    public TValue Remove( TKey key ) {
        if (this.ContainsKey( key ) || base.ContainsKey( key )) {
            var value = this[key];
            this.Remove( IndexOfKey( key ) );
            return value;
        }
        return default( TValue );
    }

    public TValue Remove( TValue value, bool isRemoveAll ) {
        if (this.ContainsValue( value ))
            this.Remove( IndexOfValue( value ) );
        while (isRemoveAll && this.ContainsValue( value ))
            Remove( value, isRemoveAll );
        return value;
    }

    public TValue Remove( int index ) {
        if (this.KeyValuePairList.Count >= index) {
            var kv = this.keyValuePairList[index];
            this.KeyValuePairList.RemoveAt( index );
            return kv.Value;
        }
        return default( TValue );
    }

    public int IndexOfKey( TKey key ) {
        int i = 0;
        foreach (var keyValuePair in KeyValuePairList) {
            if (Equals( keyValuePair.Key, key ))
                return i;
            else
                i++;
        }
        return -1;
    }

    public int IndexOfValue( TValue value ) {
        int i = 0;
        foreach (var keyValuePair in KeyValuePairList) {
            if (keyValuePair.Value.Equals( value ))
                return i;
            else
                i++;
        }
        return -1;
    }

    public bool ContainsKey( TKey key ) {
        return IndexOfKey( key ) > -1;
    }

    public bool ContainsValue( TValue value ) {
        return IndexOfValue( value ) > -1;
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
        foreach (var keyValuePair in KeyValuePairList)
            yield return keyValuePair;
    }

    public virtual TValue AtIndex( int index ) {
        return KeyValuePairList[index].Value;
    }

    public virtual void AtIndex( int index, TValue value ) {
        KeyValuePairList[index] = new KeyValuePair<TKey, TValue>( KeyValuePairList[index].Key, value );
        base[KeyValuePairList[index].Key] = value;
    }

    public override string ToString() {
        string itemListString = (this.IsEmpty ? "<< bos >>" : "");
        foreach (KeyValuePair<TKey, TValue> kvPair in this)
            itemListString += string.Format( "([{0}], [{1}])  \n", kvPair.Key, kvPair.Value );

        return string.Format(
            "{0}"
            , itemListString
            );

        /*
        return String.Format(
            "{{{0}}}\n     Count: {1}\n     KeyType: {{{2}}}, ValueType: {{{3}}}\n     Items:\n{4}"
            , this.GetType().ToString()
            , this.Count
            , typeof( TKey ).ToString()
            , typeof( TValue ).ToString()
            , itemListString
            );
         */
    }
}
