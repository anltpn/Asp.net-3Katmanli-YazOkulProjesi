using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALOgrenci
    {
        public static int OgrenciEkle(EntityOgrenci parametre)
        {
            SqlCommand komut = new SqlCommand("insert into Ogrenciler (OgrenciAd,OgrenciSoyad,OgrenciNumara,OgrenciFotograf,OgrenciSifre)  values (@p1,@p2,@p3,@p4,@p5)", Baglanti.bagla);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", parametre.AD);
            komut.Parameters.AddWithValue("@p2", parametre.SOYAD);
            komut.Parameters.AddWithValue("@p3", parametre.NUMARA);
            komut.Parameters.AddWithValue("@p4", parametre.FOTOGRAF);
            komut.Parameters.AddWithValue("@p5", parametre.SIFRE);
            return komut.ExecuteNonQuery();
        }

        public static List<EntityOgrenci> OgrenciListesi()
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut2 = new SqlCommand("Select * from Ogrenciler", Baglanti.bagla);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.ID = Convert.ToInt32(dr["OgrenciID"].ToString());
                ent.AD = dr["OgrenciAd"].ToString();
                ent.SOYAD = dr["OgrenciSoyad"].ToString();
                ent.NUMARA = dr["OgrenciNumara"].ToString();
                ent.FOTOGRAF = dr["OgrenciFotograf"].ToString();
                ent.SIFRE = dr["OgrenciSifre"].ToString();
                ent.BAKİYE = Convert.ToDouble(dr["OgrenciBakiye"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static bool OgrenciSil ( int parametre)
        {
            SqlCommand komut3 = new SqlCommand("Delete from Ogrenciler where OgrenciID=@p1", Baglanti.bagla);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", parametre);
            return komut3.ExecuteNonQuery() > 0;
        }

        public static List<EntityOgrenci> OgrenciDetay(int id)
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut4 = new SqlCommand("Select * from Ogrenciler where OgrenciID=@p1", Baglanti.bagla);
            komut4.Parameters.AddWithValue("@p1", id);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            SqlDataReader dr = komut4.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.AD = dr["OgrenciAd"].ToString();
                ent.SOYAD = dr["OgrenciSoyad"].ToString();
                ent.NUMARA = dr["OgrenciNumara"].ToString();
                ent.FOTOGRAF = dr["OgrenciFotograf"].ToString();
                ent.SIFRE = dr["OgrenciSifre"].ToString();
                ent.BAKİYE = Convert.ToDouble(dr["OgrenciBakiye"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static bool OgrenciGuncelle(EntityOgrenci deger)
        {
            SqlCommand komut5 = new SqlCommand("Update Ogrenciler set OgrenciAd=@p1,OgrenciSoyad=@p2,OgrenciNumara=@p3,OgrenciFotograf=@p4,OgrenciSifre=@p5 where OgrenciID=@p6", Baglanti.bagla);
            if (komut5.Connection.State != ConnectionState.Open)
            {
                komut5.Connection.Open();
            }
            komut5.Parameters.AddWithValue("@p1", deger.AD);
            komut5.Parameters.AddWithValue("@p2", deger.SOYAD);
            komut5.Parameters.AddWithValue("@p3", deger.NUMARA);
            komut5.Parameters.AddWithValue("@p4", deger.FOTOGRAF);
            komut5.Parameters.AddWithValue("@p5", deger.SIFRE);
            komut5.Parameters.AddWithValue("@p6", deger.ID);
            return komut5.ExecuteNonQuery() > 0;
        }
    }
}
