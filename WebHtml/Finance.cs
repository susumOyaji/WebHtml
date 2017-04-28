﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebHtml
{

    public partial class Finance
    {
        //public static async Task<List<Price>> Parse( )
        public static List<Price> Parse(string responce)
        {
            List<Price> prices = new List<Price>(); //ｺﾝｽﾄﾗｸﾀ
            //SaveLoadCS saveLoadCS = new SaveLoadCS();

            // UTF8のファイルの読み込み Edit.        
            //string response = await saveLoadCS.DataLoadAsync();//登録データ読み込み  
            string[] rows = responce.Replace("\n,", "\n").Split('\n');  //\r to delete & \n split 

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row)) continue;

                string[] cols = row.Split(',');

                Price p = new Price();
                p.Name = cols[0];//企業コード
				p.Stocks = Convert.ToDecimal( cols[1]);//保有数
                p.Itemprice = Convert.ToInt64(cols[2]);//購入単価
                prices.Add(p);

            }
            return prices;
        }
    }

    public partial class Price
    {
        public string Name { get; set; }//会社名*
        public decimal Stocks { get; set; }//保有数*
        public decimal Itemprice { get; set; }//購入価格*
        public string Realprice { get; set; }//現在値**
        public string Prev_day { get; set; }//前日比±**
        public string Percent { get; set; }//前日比％**
        public string   Polar { get; set; }//
    
        public decimal Ask { get; set; }//買値
		public decimal Bid { get; set; }//売値/取引値
				
		public double TotalAsset { get; set; }//現在評価額合計
    }

}
