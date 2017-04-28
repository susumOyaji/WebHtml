using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;




namespace WebHtml
{
	public partial class WebSerchi : ContentPage
	{
		bool Flipflop =true, Flipflop1 = true, Flipflop2 = true;
        
		Button timerButton = new Button();
	
		Label Goingprice = new Label();
		Button Probability = new Button();
		Label Goingprice1 = new Label();
		Button Probability1 = new Button();
        Button UptoAsset = new Button();
        Label TotalAsset;// = new Label();
        Label Investmen = new Label();

		Entry usercode, usercost, usershares;
		SaveLoadCS saveLoadCS = new SaveLoadCS();
        string[] responceAray;      
        StackLayout[] stack;
        StackLayout Allstack = new StackLayout();


        //ボタンコントロール配列のフィールドを作成
        Button[] UptoButtons;// = new Button[count];
        Label[] AddCity;// = new Label[count];
        Label[] AddAsk;
        Label[] AddGoingprice;// = new Label[count];

        List<Price> resPrice;
        int Realprice = 0;
        int Prev_day = 1;
        int Percent = 2;
        int Polar = 3;



        public WebSerchi()
		{
			Padding = new Thickness(5, Device.OnPlatform(30, 10, 10), 10, 10);
			DateTime time = DateTime.Now;//new System.DateTime("yyyy", 1, 1, 0, 0, 0, 0);
           
            BackgroundColor = Color.Black;
         

			StackLayout Date = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Horizontal,
                //BackgroundColor =Color.Gray,
				Children = {
					new Label
					{
						Text = time.ToString("yyyy年MM月dd日    HH時mm分ss秒"),
                        TextColor = Color.White,  //Reloadtime(1);
					}	           
				}
			};




			Label City = new Label
			{
				Text = "NEWYORK",
				TextColor = Color.Yellow,
				WidthRequest = 250,
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = 15,
			};
			Goingprice = new Label
			{
				Text = "Goingprice",
                TextColor = Color.White,
				WidthRequest = 250,
				HorizontalTextAlignment = TextAlignment.End,
				VerticalTextAlignment = TextAlignment.Center
			};
			Probability = new Button 
            { Text = "Probability", TextColor = Color.Black, WidthRequest = 80,HeightRequest = 35};
            
			StackLayout NewyorkLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,

				Spacing = 2,
				Children = { City, Goingprice, Probability }
			};



			Label City1 = new Label
			{
				Text = "TOKYO",
				TextColor = Color.Yellow,
				WidthRequest = 250,
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = 15,
			};
			Goingprice1 = new Label
			{
				Text = "Goingprice",
                TextColor = Color.White,
				WidthRequest = 250,
				HorizontalTextAlignment = TextAlignment.End,
				VerticalTextAlignment = TextAlignment.Center
			};
			Probability1 = new Button 
            { Text = "Probability", TextColor = Color.Black, WidthRequest = 80,HeightRequest = 35 };
            

			StackLayout TokyoLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,

				Spacing = 2,
				Children = { City1, Goingprice1, Probability1 }
			};


            BoxView LineBox = new BoxView
            {
                Color = Color.White,
                HeightRequest = 2,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Label TitleAsset = new Label
            {
                Text = "資産状況",
                TextColor = Color.Gray,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                WidthRequest = 80,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.End,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.End,
            };

            Label TitleTotal = new Label
            {
                Text = "投資総額",
                TextColor = Color.Gray,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                WidthRequest = 100,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
            };

            Label TitleStock = new Label
            {
                Text = "株価総額",
                TextColor = Color.Gray,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                WidthRequest = 100,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
            };
                
			StackLayout AssetTitle = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HeightRequest = 13,
				Children ={TitleAsset,TitleTotal,TitleStock}
            };



			Label Asset = new Label
			{
				Text = "Asset",
                TextColor = Color.Lime,
				WidthRequest = 150,
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalTextAlignment = TextAlignment.Center,
				//FontSize = 15,
                FontSize = Device.GetNamedSize(NamedSize.Medium ,typeof(Label)),
			};
            Investmen = new Label
            {
                Text = "Invest",
                //FontSize = 9,
                TextColor = Color.White,
                WidthRequest = 150,
                //BackgroundColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.End,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic
            };

            TotalAsset = new Label
			{
				Text = "Total Asset",
				TextColor = Color.Lime,
				WidthRequest = 250,
				HeightRequest = 30,// OnPlatform(20, 0, 0),//;//30,
				HorizontalTextAlignment = TextAlignment.End,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				//Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
			};
			UptoAsset = new Button
            { 
                Text = "UpAsset",
                TextColor = Color.FromHex("FFFFFF"),
                WidthRequest = 80,
                HeightRequest = 35,
                BackgroundColor = Color.Gray
            };


			StackLayout AssetLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
				Orientation = StackOrientation.Horizontal,

                Spacing = 0,
				Children = { 
                    new StackLayout{
                        VerticalOptions = LayoutOptions.End,
                        Spacing = 0,

                        Children = { AssetTitle },
                    },Asset, Investmen, TotalAsset, UptoAsset,
                }

			};





			Button DelButton = new Button
			{
				Text = "DEL",
                WidthRequest = 80,
                HeightRequest = 15,
			};
			DelButton.Clicked += saveLoadCS.DeleteButton_Clicked ;


		
/***************************************** MainDisplay ***************************************/

			StackLayout Toplayout = new StackLayout
			{
				Spacing = 3,
				Children ={
							Date, NewyorkLayout, TokyoLayout,AssetTitle, AssetLayout,LineBox,
							new StackLayout{
									Orientation = StackOrientation.Horizontal,
									HorizontalOptions = LayoutOptions.Center,
                                    Children ={
									timerButton,DelButton//*******************************************
									}
								},
								new StackLayout {
									Orientation = StackOrientation.Horizontal,
									HorizontalOptions = LayoutOptions.Center,
									Children ={
									new Label
									{
										Text = "企業コード",
										TextColor = Color.Gray,
										FontSize = Device.GetNamedSize(NamedSize.Micro ,typeof(Label)),
										WidthRequest = 100,
										HorizontalTextAlignment = TextAlignment.Start,
										VerticalTextAlignment = TextAlignment.End,

									},
									new Label
									{
										Text = "買値",
										TextColor = Color.Gray,
										FontSize = Device.GetNamedSize(NamedSize.Micro ,typeof(Label)),
										WidthRequest = 100,
										HorizontalTextAlignment = TextAlignment.Start,
										VerticalTextAlignment = TextAlignment.Center,
									},

									new Label
									{
										Text = "株価",
										TextColor = Color.Gray,
										FontSize = Device.GetNamedSize(NamedSize.Micro ,typeof(Label)),
										WidthRequest = 100,
										HorizontalTextAlignment = TextAlignment.Start,
										VerticalTextAlignment = TextAlignment.Center,
									},


								}
							}
						}
				};

		
		    Personaldata();

			StackLayout Secondlayout = new StackLayout
			{
				Children = {
					new ScrollView
					{
						Content=Allstack
					}
				}
			};



			StackLayout Baselayout = new StackLayout
			{
				//BackgroundColor = Color.Black,

                Children = {
					Toplayout,
					Secondlayout,
				}
			};
			Content = Baselayout;

           

			/// <summary>
            /// Uptos the buttons clicked.
            /// </summary>
            /// <param name="sender">Sender.</param>
            /// <param name="e">E.</param>
            /// <param name="i">The index.</param>
			timerButton.Clicked += (sender, e) =>
			{
				Reloadtime(1);
			};


            /// <summary>
            /// Probability.s the clicked.
            /// </summary>
            /// <param name="sender">Sender.</param>
            /// <param name="e">E.</param>
            Probability.Clicked += async (object sender, EventArgs e) =>
            {
                ////非同期でダウンロード
                //var str = await Download("^DJI");//Newyork
                string[] Dprice = await Getserchi("^DJI");//Newyork

				 Goingprice.Text = Dprice[Realprice];// g.current_value;
                if (Flipflop)
                {
                    Probability.Text = Dprice[Prev_day];//g.previous_value;
                   //Flipflop  = false;
                }
                else {
                    Probability.Text = Dprice[Percent];//g.previous_value1;
                    //Flipflop = true;
                }
                Flipflop = !Flipflop;
            };

         

            /// <summary>
            /// Uptos the buttons clicked.
            /// </summary>
            /// <param name="sender">Sender.</param>
            /// <param name="e">E.</param>
            /// <param name="namecode">Namecode.</param>
            Probability1.Clicked += async (object sender, EventArgs e) =>
           {
              	//非同期でダウンロード
				string[] Dprice = await Getserchi("998407");

			   Goingprice1.Text = Dprice[Realprice];

			   if (Flipflop1)
			   {
				   	Probability1.Text = Dprice[Prev_day];
			   }
			   else {
				   		Probability1.Text = Dprice[Percent];
			   }
               Flipflop1 = !Flipflop1;
           };

            /// <summary>
            /// Uptos the buttons clicked.
            /// </summary>
            /// <param name="sender">Sender.</param>
            /// <param name="e">E.</param>
            /// <param name="namecode">Namecode.</param>
            UptoAsset.Clicked += (object sender, EventArgs e) =>
            {
               
                UpPersonaldata();
                //if (polarity = true)//
                //{
                //    Probability1.BackgroundColor = Color.Red;
                //}
                //else {
                //    Probability1.BackgroundColor = Color.Green;
                //}

                //if (Flipflop1)
                //{
                //    Probability1.Text = g.previous_value;
                //    Flipflop1 = false;
                //}
                //else {
                //    Probability1.Text = g.previous_value1;
                //    Flipflop1 = true;
                //}
            };

            //SetupData();
            //Personaldata();
            var a = UpNewYork();
            var b = UpTokyo();
            var c = UpPersonaldata();


            //Reloadtime(3);

        }//m to end

           
    

  //////////////////////////             ボタンを押した時の処理             ///////////////////////   
                              
       /// <summary>
       /// Uptos the buttons clicked.
       /// </summary>
       /// <param name="sender">Sender.</param>
       /// <param name="e">E.</param>
        private void PersonalUpButtons_Clicked(object sender, EventArgs e)
        {
            int strId = Convert.ToUInt16( ((Button)sender).StyleId);
            int i = 0;

           
            foreach (Price price in resPrice)
            {
                if (i == strId & Flipflop2)
                {
                    UptoButtons[i].Text = price.Percent;
                }
                if (i == strId & !Flipflop2)
                {
                    UptoButtons[i].Text = price.Prev_day;
                }
                AddGoingprice[i].Text = price.Realprice;
                 i = i+1;
            }
            Flipflop2 = !Flipflop2;
        }




        /// <summary>
        /// Ons the label clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private async void OnLabelClicked(object sender, EventArgs e)
        {
            var str = ((Label)sender).Text;
            string strId = ((Label)sender).StyleId;
            int StrId = Convert.ToInt16(strId);
            var i = 0;
           
            usercode = new Entry { Placeholder = "Code", Keyboard = Keyboard.Text, };
            usercost = new Entry { Placeholder = "株数", Keyboard = Keyboard.Numeric };
            usershares = new Entry { Placeholder = "買価", Keyboard = Keyboard.Numeric };
                
            Button Save = new Button { BackgroundColor = Color.Gray, Text = "Save" };
            Save.Clicked += Entry_Completed;
           
            Button Cancel = new Button { BackgroundColor = Color.Red, Text = "Cansel" };
            Cancel.Clicked += Entry_Cancel;

            Button Edit = new Button { BackgroundColor = Color.Gray, Text = "Edit" };
            Edit.Clicked += (object s, EventArgs  f) => Edit_Completed(sender, e ,StrId);
            Edit.IsEnabled = false;

            Content = new StackLayout
            {
                Padding = 20,
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.Start,
                Children = { usercode, usercost, usershares,
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        Orientation = StackOrientation.Horizontal,
                        Children ={
                            Save,Cancel,Edit
                        }
                     }
                }
            };


            if (str != "Add")
            {
                Save.IsEnabled = false;
                Edit.IsEnabled = true;

                // UTF8のファイルの読み込み Edit.        
                string responce = await saveLoadCS.DataLoadAsync();//登録データ読み込み
                List<Price> prices = Finance.Parse(responce);

                responceAray = new string[prices.Count * 3];

                foreach (Price price in prices)
                {
                    responceAray[0 + i] = price.Name;
                    responceAray[1 + i] = Convert.ToString(price.Stocks);
                    responceAray[2 + i] = Convert.ToString(price.Itemprice) + '\n';
                    i = i + 3;
                }
                usercode.Text = responceAray[0 + StrId * 3];//price.Name;
                usercost.Text = responceAray[1 + StrId * 3];//price.Stocks;
                usershares.Text = responceAray[2 + StrId * 3];//price.Itemprice;
                //await DisplayAlert("Anser", "ID= " + strId + "    " + Convert.ToString(prices[StrId].Name), "Ok");
            }
          
         
        }



        /// <summary>
        /// Entries the completed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void Edit_Completed(object sender, EventArgs e,int Id)
        {
            await saveLoadCS.DataDeleteAsync();

            responceAray[0 + Id * 3] = usercode.Text;//price.Name;
            responceAray[1 + Id * 3] = usercost.Text;//price.Stocks;
            responceAray[2 + Id * 3] = usershares.Text;//price.Itemprice;
            string CsvData = string.Join(",", responceAray);
            await saveLoadCS.DataSaveAsync(CsvData);

            //var d = UpPersonaldata();
            Application.Current.MainPage = new WebSerchi();
        }




    



        /// <summary>
        /// Entries the completed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void Entry_Completed(object sender, EventArgs e)
        {
            
            string Usercode = usercode.Text;
            string Usercost = usercost.Text;
            string Usershares = usershares.Text;
            string[] cols;
            //string[] savedata;
            string[] entrydata = new string[3];
            string[] mergedArray = entrydata;
            string[] returncode = new string[] { "\n" };


            if (Usercode == "")
            {
               await DisplayAlert("failed", " Erro is InputData", "OK");
                Application.Current.MainPage = new WebSerchi();

            }
            else
            {
                if (Usercost == null) Usercost = "0";
                if (Usershares == null) Usershares = "0";
                string response = await saveLoadCS.DataLoadAsync();//.Replace("\r", "").Split('\n');
                string[] rows = response.Split('\r');
                cols = rows;
                entrydata[0] = Usercode;//usercode.Text = "Code or Cost or Usershares failed";
                entrydata[1] = Usercost;
                entrydata[2] = Usershares;
              
                if (response != "")
                {
                    foreach (string row in rows)
                    {
                        if (string.IsNullOrEmpty(row)) continue;
						cols = row.Split(',');
					}
                    //Concatで連結して、ToArrayで配列にする
                    mergedArray = cols.Concat(entrydata).ToArray();
                }

            }
            // 配列内のデータをすべてカンマ区切りで連結する
            string CsvData = string.Join(",", mergedArray);
            await saveLoadCS.DataSaveAsync(CsvData + "\n");
            await DisplayAlert("SAVE", " is InputData", "OK");
            //InsertRange メソッド

            //6758,9437,9837
            Application.Current.MainPage = new WebSerchi();
        }





        /// <summary>
        /// Entries the cancel.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Entry_Cancel(object sender, EventArgs e)
        {
            //this.LayoutChanged += On; //Secondlayout();
            Application.Current.MainPage = new WebSerchi();
        }





        /// <summary>
        /// Updates the new york.
        /// </summary>
		public async Task UpNewYork()
		{

			//非同期でダウンロード
			//var str = await Getserchi("^DJI");//Newyork

			string[] Dprice =  await Getserchi("^DJI");

			if (Dprice[Polar] != "-")//
			{
				Probability.BackgroundColor = Color.Red;
			}
			else {
				Probability.BackgroundColor = Color.Green;
			}
			Goingprice.Text = Dprice[Realprice];


			if (Flipflop)
			{
             	Probability.Text = Dprice[Prev_day];
				//Display =  false;
			}
			else {
					Probability.Text = Dprice[Percent];
		     		//Display = true;
			}
            Flipflop = !Flipflop;
		}


        /// <summary>
        /// Updates the tokyo.
        /// </summary>
		public async Task UpTokyo()
		{
			//非同期でダウンロード
			//var str = await Download("998407");//Tokyoo
			string[] Dprice = await Getserchi("998407");


			if (Dprice[Polar] != "-")//
			{
				Probability1.BackgroundColor = Color.Red;
			}
			else {
				Probability1.BackgroundColor = Color.Green;
			}
			Goingprice1.Text = Dprice[Realprice];// g.current_value;

			if (Flipflop1)
			{
               	Probability1.Text = Dprice[Prev_day];// g.previous_value;
				//Display1 = false;
			}
			else {
					Probability1.Text = Dprice[Percent];// g.previous_value1;	
				    //Display1 = true;
			}
            Flipflop1 = !Flipflop1;
		}

       



        /// <summary>
        /// Updates the privatedata.
        /// </summary>
        private async Task UpPersonaldata()
        {
            int index = 0;
			int i = 0;
			Decimal PayAssetprice = 0;
			Decimal TotalAssetprice = 0;

            // UTF8のファイルの読み込み Edit.        
            //string responce = await saveLoadCS.DataLoadAsync();//登録データ読み込み         

            /*List<Price>*/ resPrice = await PasonalGetserchi();//登録件数設定
			foreach (Price price in resPrice)
			{
				PayAssetprice = PayAssetprice + Convert.ToDecimal(price.Stocks) * Convert.ToDecimal(price.Itemprice);//保有数*購入価格=投資総額

                Investmen.Text = /*String.Format("{0:#,0}",PayAssetprice);*/ Convert.ToString(PayAssetprice);//投資総額

				if (price.Realprice != "---")
				{
					TotalAssetprice = TotalAssetprice + Convert.ToDecimal(price.Stocks) * Convert.ToDecimal(price.Realprice);//保有数*時価=時価総額
                    TotalAsset.Text = String.Format("{0:#,00}",TotalAssetprice);// Convert.ToString(TotalAssetprice);//時価総額
				}
				else {
					TotalAsset.Text = "Close";
				}

				if (price.Polar != "-")
				{
					UptoButtons[i].BackgroundColor = Color.Red;//各銘柄
				}
				else {
					UptoButtons[i].BackgroundColor = Color.Green;
				}

                AddGoingprice[i].Text = price.Realprice;//時価
				i = i + 1;
				index = index + 1;
			}

            float RealValue = Convert.ToInt64( TotalAssetprice - PayAssetprice);
           
            UptoAsset.Text = String.Format("{0:#,0}", RealValue); // 変換後*/Convert.ToString(RealValue);//利益総額

			Decimal pasent = Convert.ToInt16((TotalAssetprice / PayAssetprice) * 100);
			string pasenttext = Convert.ToString(pasent)+"%";	
			            
            if (PayAssetprice <= TotalAssetprice)//
            {
                UptoAsset.BackgroundColor = Color.Red;//総合銘柄
            }
            else {
                UptoAsset.BackgroundColor = Color.Green;
            }


    	}
        



        /// <summary>
        /// Privatedata this instance.
        /// </summary>
        private async Task Personaldata()
        {
            int index = 0;
            int count = 0;
            int i = 0;
           
            // UTF8のファイルの読み込み Edit.        
            /*List<Price>*/ resPrice = await PasonalGetserchi();//登録件数設定
                 
            stack  = new StackLayout[resPrice.Count+1];//1=最下行追加分
            AddCity = new Label[resPrice.Count+1];
            AddAsk = new Label[resPrice.Count+1];
            AddGoingprice = new Label[resPrice.Count+1];
            UptoButtons = new Button[resPrice.Count+1];

         
            foreach (Price price in resPrice)
            {
				AddCity[i] = new Label
                {
                        Text = price.Name,
                        TextColor = Color.FromHex("FFFFFF"),
                        WidthRequest = 250,
                        HorizontalTextAlignment = TextAlignment.Start,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontSize = 15,
                        StyleId = i.ToString()
                    };
                    //ラベルタッチでイベントを発生させる
                    var tgr = new TapGestureRecognizer();
                    var res = tgr.NumberOfTapsRequired;
                    tgr.Tapped += (sender, e) => OnLabelClicked(sender, e );
                    AddCity[i].GestureRecognizers.Add(tgr);
                    
                    AddAsk[i] = new Label
                    {
                        Text = String.Format("{0:#,00}", price.Itemprice),//Convert.ToString(price.Itemprice),
                        TextColor = Color.FromHex("EE6600"),
                        WidthRequest = 250,
                        HorizontalTextAlignment = TextAlignment.Start,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontSize = 15
                    };

                    AddGoingprice[i] = new Label
                    {
                        Text = Convert.ToString(price.Realprice),
                        TextColor = Color.FromHex("FFFFFF"),
                        WidthRequest = 250,
                        HorizontalTextAlignment = TextAlignment.End,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontSize = 15
                    };

                UptoButtons[i] = new Button
                {
                    Text = Convert.ToString(price.Prev_day),//前日比±//"UptoAcet" + prices.Count,
                    HeightRequest = 35,
                    WidthRequest = 80,
                    TextColor = Color.FromHex("FFFFFF"),
                    BackgroundColor = Color.Gray,
                    StyleId = i.ToString(),
                    };                                                  
				   	UptoButtons[i].Clicked += (sender, e) => PersonalUpButtons_Clicked(sender, e);
                    
					stack[i] = new StackLayout();
                    stack[i].Orientation = StackOrientation.Horizontal;
                    stack[i].Children.Add(AddCity[i]);//Label
                    stack[i].Children.Add(AddAsk[i]);
                    stack[i].Children.Add(AddGoingprice[i]);
                    stack[i].Children.Add(UptoButtons[i]);

                    Allstack.Children.Add(stack[i]);
                    i = i + 1;
                    count = count + 1;
                    index = index + 1;
        		//}//catch to end

            }//for to end
                
            //最下行に新規登録行追加
            AddCity[i] = new Label
            {
                Text = "Add",
                TextColor = Color.FromHex("FFFFFF"),
                WidthRequest = 250,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 15
            };
            //ラベルタッチでイベントを発生させる
            var tgrr = new TapGestureRecognizer();
            tgrr.Tapped += (sender, e) => OnLabelClicked(sender, e);
            AddCity[i].GestureRecognizers.Add(tgrr);

            AddGoingprice[i] = new Label
            {
                Text = "Non",
                TextColor = Color.FromHex("FFFFFF"),
                WidthRequest = 250,
                HorizontalTextAlignment = TextAlignment.End,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 15
            };

            UptoButtons[i] = new Button
            {
                Text = "Non",
                WidthRequest = 80,
                HeightRequest = 35,
                TextColor = Color.FromHex("FFFFFF"),
                //BackgroundColor = Color.Red
            };
            //UptoButtons[i].Clicked += uptoButtons_Clicked;

            stack[i] = new StackLayout();
            stack[i].Orientation = StackOrientation.Horizontal;
            stack[i].Children.Add(AddCity[i]);//Label
            stack[i].Children.Add(AddGoingprice[i]);
            stack[i].Children.Add(UptoButtons[i]);

            Allstack.Children.Add(stack[i]);
            i = i + 1;
            count = count + 1;
            index = index + 1;
        }//Mesoth to end

      







		

		/// <summary>
		/// Getserchi the specified code.
		/// </summary>
		/// <param name="code">Code.</param>
		public async Task<string[]> Getserchi(string code)
		{
			string TrgetWord = null, TrgetWord1 = null, TrgetWord2 = null;
			string[] price = new string[4];
			//bool polarity = true;


			string url = "http://stocks.finance.yahoo.co.jp/stocks/detail/?code=" + code;// +".T";

			var httpClient = new HttpClient();
			string str =await httpClient.GetStringAsync(url);

			string searchWord = "stoksPrice";    //検索する文字列 ="stoksPrice"> 
			int foundIndex = str.IndexOf(searchWord);//始めの位置を探す
													 //次の検索開始位置
			int nextIndex = foundIndex + searchWord.Length;
			try
			{
				//次の位置を探す
				foundIndex = str.IndexOf(searchWord, nextIndex);
				if (foundIndex != -1)
				{
					int i = searchWord.Length + 2;//pricedata to point
					for (; Convert.ToString(str[foundIndex + i]) != "<"; i++)
					{
						TrgetWord = TrgetWord + Convert.ToString(str[foundIndex + i]);//current value 現在値
					}
				}
				else {
					price[0] = "Error";
				}

				string searchWord1 = "yjMSt"; //検索する文字列前日比
				int foundIndex1 = str.IndexOf(searchWord1);//始めの位置を探す
				int i1 = searchWord1.Length + 2;

				for ( ; Convert.ToString(str[foundIndex1 + i1]) != "（"; i1++)
				{
                    TrgetWord1 = TrgetWord1 + str[foundIndex1 + i1];//previous 前日比? ¥
				}

				if (Convert.ToString(str[foundIndex1 + i1 + 1]) == "-")//(－)下落
				{
					price[3]  = "-";
				}


				i1++;
				for (; Convert.ToString(str[foundIndex1 + i1]) != "）"; i1++)
				{
					TrgetWord2 = TrgetWord2 + str[foundIndex1 + i1];//previous 前日比? %
				}
				price[0] = TrgetWord;//return code
				price[1] = TrgetWord1;//return price
                price[2] = TrgetWord2;
			    
            
			}catch(Exception e)
			{
                //var accepted = await DisplayAlert(e.Message,"市場が開始していません。", "Ok","Cancel");
                //if (accepted== true)
                //{
                //    Application.Current.MainPage = new WebSerchi();
                //    //Navigation.InsertPageBefore(new WebSerchi(), this);
                //    //buttonDialog1.Text = "Accepted!";
                //    //break;
                //}

			}
            return price;// polarity;
		}//class to end	





       /// <summary>
       /// Pasonals the getserchi.
       /// </summary>
       /// <returns>The getserchi.</returns>
        public async Task<List<Price>> PasonalGetserchi()
        {
            string TrgetWord = null, TrgetWord1 = null, TrgetWord2 = null;
            int index = 0;

            // UTF8のファイルの読み込み Edit.        
            string responce = await saveLoadCS.DataLoadAsync();//登録データ読み込み
															   
            List<Price> prices = Finance.Parse(responce);

            foreach (Price price in prices)
            {
               string url = "http://stocks.finance.yahoo.co.jp/stocks/detail/?code=" + price.Name;// +".T";

                var httpClient = new HttpClient();
                string str = await httpClient.GetStringAsync(url);

                string searchWord = "stoksPrice";    //検索する文字列 ="stoksPrice"> 
                int foundIndex = str.IndexOf(searchWord);//始めの位置を探す
                                                     //次の検索開始位置
                int nextIndex = foundIndex + searchWord.Length;
                try
                {
                    //次の位置を探す
                    foundIndex = str.IndexOf(searchWord, nextIndex);
                    if (foundIndex != -1)
                    {
                        int i = searchWord.Length + 2;//pricedata to point
                        for (; Convert.ToString(str[foundIndex + i]) != "<"; i++)
                        {
                            TrgetWord = TrgetWord + str[foundIndex + i];//current value 現在値
                        }
                    }
                    else {
                    //price[0] = "Error";
                    }

                    string searchWord1 = "yjMSt"; //検索する文字列前日比
                    int foundIndex1 = str.IndexOf(searchWord1);//始めの位置を探す
                    int i1 = searchWord1.Length + 2;

                    for (; Convert.ToString(str[foundIndex1 + i1]) != "（"; i1++)
                    {
                        TrgetWord1 = TrgetWord1 + str[foundIndex1 + i1] ;//previous 前日比? ¥
                    }

					if (Convert.ToString(str[foundIndex1 + i1 + 1]) == "-")//(－)下落
					{
						price.Polar = "-";
					}
					else {
						price.Polar = "+";
					}


                    i1++;
                    for (; Convert.ToString(str[foundIndex1 + i1]) != "）"; i1++)
                    {
                        TrgetWord2 = TrgetWord2 + str[foundIndex1 + i1];//previous 前日比? %
                    }
				
                    price.Realprice = TrgetWord;//現在値
                    price.Prev_day = TrgetWord1;//前日比±
                    price.Percent = TrgetWord2; //前日比％
				
                    TrgetWord = "";
                    TrgetWord1 = "";
                    TrgetWord2 = "";
						///
					//Pasonalresponce[index] = price.Name + ","+ Convert.ToString(price.Stocks) + "," + Convert.ToString(price.Itemprice);
                    index = index + 1; 
                }
                catch (Exception e)
                {   
                    //var accepted = await DisplayAlert(e.Message, "市場が開始していません。", "Ok", "Cancel");
                    //if (accepted == true)
                    //{   
                    //    Application.Current.MainPage = new WebSerchi();
                    //    //Navigation.InsertPageBefore(new WebSerchi(), this);
                    //    //buttonDialog1.Text = "Accepted!";
                    //    //break;
                    //}
                }
            }

            return prices;//polarity;
        }//class to end 

       




        /// <summary>
        /// Download the specified code.
        /// </summary>
        /// <param name="code">Code.</param>
        async Task<String> Download(string code)
        {
            string url = "http://stocks.finance.yahoo.co.jp/stocks/detail/?code=" + code;// +".T";

            var httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);

        }






        /// <summary>
        /// Reloadtime the specified Sec.
        /// </summary>
        /// <param name="Sec">Sec.</param>
        public void Reloadtime(int Sec)
		{
			timerButton.Text = "timer running...";
			Device.StartTimer(new TimeSpan(0, 0, Sec), () =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					// interact with UI elements
					timerButton.Text = DateTime.Now.ToString("mm:ss") + " past the hour";
					var notuse_UpdateNewYork = UpNewYork();
					var notuse_UpdateTokyo = UpTokyo();
					UpPersonaldata();
				});
				return true; // runs again, or false to stop
			});
		}


}//class to end













/*
//using System;
//using Xamarin.Forms;

//namespace LoginNavigation
//{
	public class LoginPageCS : ContentPage
	{
		Entry usernameEntry, passwordEntry;
		Label messageLabel;

		public LoginPageCS()
		{
			var toolbarItem = new ToolbarItem
			{
				Text = "Sign Up"
			};
			toolbarItem.Clicked += OnSignUpButtonClicked;
			ToolbarItems.Add(toolbarItem);

			messageLabel = new Label();
			usernameEntry = new Entry
			{
				Placeholder = "username"
			};
			passwordEntry = new Entry
			{
				IsPassword = true
			};
			var loginButton = new Button
			{
				Text = "Login"
			};
			loginButton.Clicked += OnLoginButtonClicked;

			Title = "Login";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Label { Text = "Username" },
					usernameEntry,
					new Label { Text = "Password" },
					passwordEntry,
					loginButton,
					messageLabel
				}
			};
		}

		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SignUpPageCS());
		}

		async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			var user = new User
			{
				Username = usernameEntry.Text,
				Password = passwordEntry.Text
			};

			var isValid = AreCredentialsCorrect(user);
			if (isValid)
			{
				App.IsUserLoggedIn = true;
				Navigation.InsertPageBefore(new MainPageCS(), this);
				await Navigation.PopAsync();
			}
			else {
				messageLabel.Text = "Login failed";
				passwordEntry.Text = string.Empty;
			}
		}

		bool AreCredentialsCorrect(User user)
		{
			return user.Username == Constants.Username && user.Password == Constants.Password;
		}
	}*/
}//namespece to end
