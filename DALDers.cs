﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALDers
    {
        public static List<EntityDers> DersListesi()
        {
            List<EntityDers> degerler = new List<EntityDers>();
            SqlCommand komut2 = new SqlCommand("Select * from Dersler", Baglanti.bagla);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EntityDers ent = new EntityDers();
                ent.ID = Convert.ToInt32(dr["DersID"].ToString());
                ent.DERSAD = dr["DersAd"].ToString();
                ent.MİN = int.Parse(dr["DersMinKontenjan"].ToString());
                ent.MAX = int.Parse(dr["DersMaxKontenjan"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
        public static int TalepEkle(EntityBasvuruForm parametre)
        {
            SqlCommand komut = new SqlCommand("insert into BasvuruFormu (OgrenciID,DersID) values (@p1,@p2)", Baglanti.bagla);
            komut.Parameters.AddWithValue("@p1", parametre.BASOGRENCIID);
            komut.Parameters.AddWithValue("@p2", parametre.BASDERSID);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            return komut.ExecuteNonQuery();
        }
    }
}
