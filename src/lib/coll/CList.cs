using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Linq;

[Serializable()]
public class CList<T> : List<T> {
    #region Get/Set
    public T this[int index] {
        get { return base[index]; }
        set {
            T
                eskiEleman = this[index]
                , yeniEleman = value;


            base[index] = value;
        }
    }

    ///<summary>Listede hiç eleman yok mu?</summary>
    public bool IsEmpty {
        get { return this.Count == 0; }
    }
    #endregion

    #region Event/Delegate
    public event Action<ListChangedType, object, int> ListChanged;
    #endregion


    #region Constructors
    public CList() {
    }

    public CList( IEnumerable<T> collection )
        : base( collection ) {
    }

    public CList( params T[] collection )
        : base( collection ) {
    }
    #endregion

    public T Add( T item ) {
        base.Add( item );

        try {
            if (ListChanged != null)
                ListChanged( ListChangedType.ItemAdded, item, IndexOf( item ) );
        }
        catch { }

        return item;
    }

    public T Add( object item ) {
        return Add( (T)item );
    }
    
    public CList<T> AddRange( object anArray ) {
        // return AddRange( (T[])anArray );
        if (!(anArray is IEnumerable))
            return null;

        var _anArray = (IEnumerable)anArray;
        AddRange( _anArray );

        return this;
    }

    public CList<T> AddRange( IEnumerable anArray ) {
        if (anArray is string && typeof( T ) == typeof( string ))
            Add( (string)anArray );
        
        var eklenenler = new CList<T>();
        foreach (var item in anArray) {
            eklenenler.Add( (T)item );
            this.Add( (T)item );
        }

        return this;
    }

    public CList<T> AddRange( IEnumerable<T> anArray ) {
        AddRange( anArray.ToArray() );

        return this;
    }

    public CList<T> AddRange( params T[] anArray ) {
        foreach (object t in anArray)
            this.Add( t );

        try {
            var indexes = new int[anArray.Length];
            for (int i = 0; i < anArray.Length; i++)
                indexes[i] = this.IndexOf( anArray[i] );
        }
        catch { }

        return this;
    }

    public T Remove( object item ) {
        var index = this.IndexOf( item );

        base.Remove( (T)item );
        
        try {
            if (ListChanged != null)
                ListChanged( ListChangedType.ItemDeleted, item, IndexOf( item ) );
        }
        catch { }

        return (T)item;
    }

    ///<summary>'item', diðerlerinde içeriliyor mu?</summary>
    public new bool Contains( object item ) {
        foreach (T buItem in this) {
            if (Equals( item, buItem ))
                return true;
        }

        return false;
    }

    ///<summary>'item' için liste indexini verir.</summary>
    public new int IndexOf( object item ) {
        return base.IndexOf( (T)item );
    }

    ///<summary>'item' için liste indexini verir.</summary>
    public new int IndexOf( object item, int startIndex ) {
        return base.IndexOf( (T)item, startIndex );
    }

    ///<summary>'item' için liste indexini verir.</summary>
    public new int IndexOf( object item, int startIndex, int count ) {
        return base.IndexOf( (T)item, startIndex, count );
    }

    public BindingList<T> asBindingList() {
        return new BindingList<T>( this );
    }

    public CList<T> GetRange( int index, int count ) {
        return base.GetRange( index, count ) as CList<T>;
    }

    ///<summary>Ýki elemanýn yerini deðiþtirir.</summary>
    public bool swap( int index1, int index2 ) {
        var tmp = this[index1];

        this[index1] = this[index2];
        this[index2] = tmp;

        return true;
    }

    ///<summary>'delim' ile elemanlarý birlestir, 'null' için newline yap.</summary>
    public string birlestir( object delim ) {
        var outStr = "";
        var atandimi = false;


        if (delim == null)
            delim = "\r\n";

        foreach (T item in this) {
            if (Equals( item, default( T ) ))
                continue;

            if (atandimi)
                outStr += delim;

            atandimi = true;
            outStr += item.ToString();
        }

        return outStr;
    }

    ///<summary>Listenin ilk elemanýný döner.</summary>
    public T first() {
        return this[0];
    }

    ///<summary>Listenin son elemanýný döner.</summary>
    public T last() {
        return this[this.Count - 1];
    }

    ///<summary>Bu ve diðer listenin 'ayný' deðerlerini, yeni dizi olarak döner.</summary>
    public CList<T> kesisim( IEnumerable<T> digerListe ) {
        var sonuc = new CList<T>();
        
        
        foreach (T item in this) {
            if (digerListe.Contains( item ))
                sonuc.Add( item );
        }

        return sonuc;
    }

    ///<summary>Verilen listedeki elemanlardan, bu listedeki farklý deðeri olan elemanlar alýnýr ve yeni liste dönülür.</summary>
    public CList<T> farklariBul( IEnumerable<T> orjListe ) {
        var sonuc = new CList<T>();

        foreach (var her in this) {
            if (!orjListe.Contains( her ))
                sonuc.Add( her );
        }
        
        return sonuc;
    }

    ///<summary>Dizinin belirli bir kýsmýný verir.</summary>
    public virtual CList<T> copyNew( int startIndex, int endIndex ) {
        var sonuc = new CList<T>();

        for (var i = startIndex; i <= endIndex; i++)
            sonuc.Add( this[i] );
        
        return sonuc;
    }

    ///<summary>Dizinin belirli bir kýsmýný verir.</summary>
    public virtual CList<T> copyNew( int startIndex ) {
        return copyNew( startIndex, this.Count - 1 );
    }

    ///<summary>Dizinin belirli bir kýsmýný verir.</summary>
    public virtual CList<T> copyNew() {
        var sonuc = new CList<T>();
        
        for (var i = 0; i < this.Count; i++)
            sonuc.Add( this[i] );
        
        return sonuc;
    }

    ///<summary>Ýlk 'firstN' kadar eleman hariç tüm elemanlarý döner.</summary>
    ///<param name="firstN">Baþtan 'kaç elemanýn' hariç tutulacaðýný belirtir.</param>
    public virtual CList<T> exceptFirst( int firstN ) {
        return copyNew( firstN, this.Count - 1 );     // Dizi boþsa, "OutOfRange" exc. verir.
    }

    ///<summary>Ýlk eleman hariç tüm elemanlarý döner.</summary>
    public virtual CList<T> exceptFirst() {
        return exceptFirst( 1 );
    }

    ///<summary>Son 'lastN' kadar eleman hariç tüm elemanlarý döner.</summary>
    ///<param name="lastN">Sondan 'kaç elemanýn' hariç tutulacaðýný belirtir.</param>
    public virtual CList<T> exceptLast( int lastN ) {
        return copyNew( 0, this.Count - lastN - 1 );     // Dizi boþsa, "OutOfRange" exc. verir.
    }

    ///<summary>Son eleman hariç tüm elemanlarý döner.</summary>
    public virtual CList<T> exceptLast() {
        return exceptLast( 1 );
    }

    ///<summary>Elemanlarý sýralar ve 'bool' döner.</summary>
    public virtual CList<T> sort( bool isReversed = false, Comparison<T> sortBlock = null ) {
        if (sortBlock == null)
            this.Sort();
        else
            this.Sort( sortBlock );

        if (isReversed)
            base.Reverse();

        return this;
    }

    ///<summary>Elemanlarý ters sýrada verir ve self döner.</summary>
    public virtual CList<T> reverse() {
        base.Reverse();

        return this;
    }

    ///<summary>Listedeki tüm elemanlarý verilen sýnýfa cast yapar.</summary>
    public CList<TDest> cast<TDest>() {
        var yeniListe = new CList<TDest>();
        foreach (object her in this)
            yeniListe.Add( (TDest)her );

        return yeniListe;
    }

    public int findFirstIndex( Func<T, bool> kosulProc ) {
        for (int i = 0; i < this.Count; i++) {
            if (kosulProc( this[i] ))
                return i;
        }

        return -1;
    }

    ///<summary>Bu listenin elemanlarýnýn string ifadesi.</summary>
    public override string ToString() {
        // var itemListString = (this.bosMu() ? "<< bos >>" : "");
        StringBuilder sb;

        sb = new StringBuilder( 1024 );
        foreach (T item in this)
            sb.AppendLine( Equals( item, default( T ) ) ? "null" : item.ToString() );

        return sb.ToString();


        //        if ( typeof( T ).FullName == typeof( DataRow ).FullName || getFirst() is DataRow )       // T'nin ya da ilk elemanýn tipi 'DataRow' ise, 'ItemArray' ini de göster.
        //            toDataRowStr();

        /*
        return string.Format(
            "{{{0}}}\n     Count: {1}\n     Type: {{{2}}}\n     Items:\n{3}"
            , this.GetType().ToString()
            , this.Count
            , typeof( T ).ToString()
            , itemListString
            );
         */
    }

    #region Operators
    ///<summary>Bu liste diðer listenin elemanlarýný birleþtirip, yeni bir liste döner.</summary>
    public static CList<T> operator +( CList<T> buListe, IEnumerable<T> digerListe ) {
        var sonuc = new CList<T>();
        sonuc.AddRange( buListe );
        sonuc.AddRange( digerListe );

        return sonuc;
    }

    ///<summary>Bu liste ile diðer liste arasýndaki farklarý yeni bir liste olarak döner.</summary>
    public static CList<T> operator -( CList<T> buListe, IEnumerable<T> digerListe ) {
        return buListe.farklariBul( digerListe );
    }
    #endregion
}
