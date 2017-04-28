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
		bool Display, Display1 = true;
		//Price price = new Price();
        //List<Price> prices = Finance.Parse;
		//List<Price> prices = new List<Price>();
		Getvalue g = new Getvalue();
		Button timerButton = new Button();
		//TextCell timer = new TextCell();
		Label City = new Label();
		Label Goingprice = new Label();
		Button Probability = new Button();
		Label City1 = new Label();
		Label Goingprice1 = new Label();
		Button Probability1 = new Button();
		Label TotalAsset = new Label();
		//StackLayout Baselayout = new StackLayout();
		//string[,] EntryData = new string[3, 3];
		Entry usercode, usercost, usershares;
		SaveLoadCS saveLoadCS = new SaveLoadCS();

        //List<Price> prices = new List<Price>();

        StackLayout[] stack;// = new StackLayout[count];
        StackLayout Allstack = new StackLayout();


        //ボタンコントロール配列のフィールドを作成
        Button[] UptoButtons;// = new Button[count];
        Label[] AddCity;// = new Label[count];
        Label[] AddGoingprice;// = new Label[count];



        public WebSerchi()
		{
			Padding = new Thickness(5, Device.OnPlatform(20, 10, 10), 10, 10);
			DateTime time = DateTime.Now;//new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
           
         

			StackLayout Date = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Horizontal,

				Children = {
					new Label
					{
						Text = time.ToString("yyyy-MM-dd HH-mm-ss")
						//Reloadtime(1);
					}	           
				}
			};




			City = new Label
			{
				Text = "City",
				TextColor = Color.Yellow,
				WidthRequest = 250,
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = 15,
			};
			Goingprice = new Label
			{
				Text = "Goingprice",
				WidthRequest = 250,
				HorizontalTextAlignment = TextAlignment.End,
				VerticalTextAlignment = TextAlignment.Center
			};
			Probability = new Button 
            { Text = "Probability", TextColor = Color.Black, WidthRequest = 80,/* BackgroundColor = Color.Red*/ };
            //this.Probability.Clicked += ProbabilityButtto_Clicked;
			//TextColor = Color.FromHex("FFFFFF")
			StackLayout NewyorkLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,

				Spacing = 2,
				Children = { City, Goingprice, Probability }
			};



			City1 = new Label
			{
				Text = "City",
				TextColor = Color.Yellow,
				WidthRequest = 250,
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = 15,
			};
			Goingprice1 = new Label
			{
				Text = "Goingprice",
				WidthRequest = 250,
				HorizontalTextAlignment = TextAlignment.End,
				VerticalTextAlignment = TextAlignment.Center
			};
			Probability1 = new Button 
            { Text = "Probability", TextColor = Color.Black, WidthRequest = 80,/* BackgroundColor = Color.Red*/ };
            //Probability1.Clicked += Probability1Button.Clicked();
            //Probability1 += (sender, e) => Probability1Button.;

			StackLayout TokyoLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,

				Spacing = 2,
				Children = { City1, Goingprice1, Probability1 }
			};


			Label Asset = new Label
			{
				Text = "Asset",
				WidthRequest = 250,
				HorizontalTextAlignment = TextAlignment.Start,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = 15,
			};
			TotalAsset = new Label
			{
				Text = "Total Asset",
				TextColor = Color.Black,
				WidthRequest = 250,
				HorizontalTextAlignment = TextAlignment.End,
				VerticalTextAlignment = TextAlignment.Center
			};
			Button UptoAsset = new Button { Text = "UptoAsset", TextColor = Color.FromHex("FFFFFF"), WidthRequest = 80,/* BackgroundColor = Color.Red*/ };


			StackLayout AssetLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,

				Spacing = 2,
				Children = { Asset, TotalAsset, UptoAsset, }

			};

			Button DelButton = new Button
			{
				Text = "DEL",
			};
			DelButton.Clicked += saveLoadCS.DeleteButton_Clicked ;
		


			StackLayout Toplayout = new StackLayout
			{
				BackgroundColor = BackgroundColor = Color.Gray, 
				Spacing = 0,
				Children ={
							Date, NewyorkLayout, TokyoLayout, AssetLayout,
							new StackLayout{
									Orientation = StackOrientation.Horizontal,
									HorizontalOptions = LayoutOptions.Center,
                                    Children ={
										timerButton,DelButton
									}
								}
						    }
			};

/*:::::::::::::::::::::::::::::::::::::::: MainDosplay ::::::::::::::::::::::::::::::::::::::::::::::::::::*/ 

			
			//var scroll = new ScrollView();
			//Content = scroll; 

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
				Children = {
					Toplayout,
					Secondlayout,
				}
			};
			Content = Baselayout;

			//UpdateNewYork();
			//UpdateTokyo();
            UpdatePrivatedata();
			Privatedata();
			
			//Reloadtime(3);

			//
			// Device.StartTimer     and     Device.BeginInvokeOnMainThread
			//
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
                await Getserchi("^DJI");//Newyork

                //City.Text = "NEWYORK";
                //Goingprice.Text = g.current_value;

                //if (polarity == true)//
                //{
                //  Probability.BackgroundColor = Color.Red;
                //}
                //else {
                //  Probability.BackgroundColor = Color.Green;
                //}

                if (Display)
                {
                    Probability.Text = g.previous_value;
                    Display = false;
                }
                else {
                    Probability.Text = g.previous_value1;
                    Display = true;
                }
            };


            /// <summary>
            /// Probability1s the button. clicked.
            /// </summary>
            /// <param name="sender">Sender.</param>
            /// <param name="e">E.</param>
            Probability1.Clicked += async (object sender, EventArgs e) =>
            {
                ////非同期でダウンロード
                //var str = await Download("998407");//Tokyoo
				await Getserchi("998407");

                //City1.Text = "TOKYO";
                //Goingprice1.Text = g.current_value;

                //if (polarity = true)//
                //{
                //  Probability1.BackgroundColor = Color.Red;
                //}
                //else {
                //  Probability1.BackgroundColor = Color.Green;
                //}

            if (Display1)
            {
                Probability1.Text = g.previous_value;
                Display1 = false;
            }
            else {
                Probability1.Text = g.previous_value1;
                Display1 = true;
            }

        };




    }//m to end

           
    ////////////////             ボタンを押した時の処理             ///////////////////////
            
     
            
          

                              
        //Buttonのクリックイベントハンドラ
        /// <summary>
        /// Uptos the buttons clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        /// <param name="namecode">Namecode.</param>
        private async void uptoButtons_Clicked(object sender, EventArgs e, string namecode)
        {
            ////非同期でダウンロード
            //var str = await Download(namecode);
            await Getserchi(namecode);

            //City1.Text = "TOKYO";
            //Goingprice1.Text = g.current_value;

            //if (polarity = true)//
            //{
            //  Probability1.BackgroundColor = Color.Red;
            //}
            //else {
            //  Probability1.BackgroundColor = Color.Green;
            //}

            if (Display1)
            {
                Probability1.Text = g.previous_value;
                Display1 = false;
            }
            else {
                Probability1.Text = g.previous_value1;
                Display1 = true;
            }
        }


        /// <summary>
        /// Ons the label clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnLabelClicked(object sender, EventArgs e, int i)
        {
            var str = ((Label)sender).Text;
            var q = Label.IsVisibleProperty;
            TotalAsset.Text = Convert.ToString(q);
            if (str == "Add")
            {
                 
                usercode = new Entry { Placeholder = "Code", Keyboard = Keyboard.Text, };
                usercode.Text = ""; ;

                usercost = new Entry { Placeholder = "Cost", Keyboard = Keyboard.Numeric };
                usercost.Text = "";

                usershares = new Entry { Placeholder = "Shares", Keyboard = Keyboard.Numeric };
                usershares.Text = "";

                Button submit = new Button { BackgroundColor = Color.Red, Text = "Save" };
                submit.Clicked += Entry_Completed;

                Button Cancel = new Button { BackgroundColor = Color.Gray, Text = "Cansel" };
                Cancel.Clicked += Entry_Cancel;

                Content = new StackLayout
                {
                    Padding = 20,
                    VerticalOptions = LayoutOptions.Start,
                    Children = { usercode, usercost, usershares,
                        new StackLayout
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            Orientation = StackOrientation.Horizontal,
                            Children ={
                                submit,Cancel
                            }
                        }
                    }
                };
            }
            else {
                //string response = await saveLoadCS.DataLoadAsync();//登録データ読み込み
                //List<Price> prices = Finance.Parse(response);
                //TextBox1をさがす。子コントロールも検索する。
                //Control[] cs = this.Controls.Find("TextBox1", true);
                //TextBox1が見つかれば、Textを変更する
                //if (cs.Length > 0)
                //  ((TextBox)cs[0]).Text += "*";

            }




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
                var anser = DisplayAlert("failed", " Erro is InputData", "OK");
                Application.Current.MainPage = new WebSerchi();

            }
            else
            {
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
            Application.Current.MainPage = new WebSerchi();
        }











        /// <summary>
        /// Updates the new york.
        /// </summary>
		public async Task UpdateNewYork()
		{

			//非同期でダウンロード
			//var str = await Download("^DJI");//Newyork

			bool str =  await Getserchi("^DJI");

			if (str == true)//
			{
				Probability.BackgroundColor = Color.Red;
			}
			else {
				Probability.BackgroundColor = Color.Green;
			}
			City.Text = "NEWYORK";
			Goingprice.Text = g.current_value;


			if (Display)
			{
				Probability.Text = g.previous_value;
				Display = false;
			}
			else {
				Probability.Text = g.previous_value1;
				Display = true;
			}

		}


        /// <summary>
        /// Updates the tokyo.
        /// </summary>
		public async Task UpdateTokyo()
		{
			//ラベルの表示を初期化する
			//status.Text = "Loding...";
			//html.Text = "";

			//非同期でダウンロード
			//var str = await Download("998407");//Tokyoo
			bool str = await Getserchi("998407");


			if (str == true)//
			{
				Probability1.BackgroundColor = Color.Red;
			}
			else {
				Probability1.BackgroundColor = Color.Green;
			}
			City1.Text = "TOKYO";
			Goingprice1.Text = g.current_value;

			if (Display1)
			{
				Probability1.Text = g.previous_value;
				Display = false;
			}
			else {
				Probability1.Text = g.previous_value1;
				Display = true;
			}

		}



		public async Task UpdateAsset()
		{
			//ラベルの表示を初期化する
			//status.Text = "Loding...";
			//html.Text = "";

			//非同期でダウンロード
			//var str = await Download("998407");//Tokyoo
			bool str = await Getserchi("998407");


			if (str == true)//
			{
				Probability1.BackgroundColor = Color.Red;
			}
			else {
				Probability1.BackgroundColor = Color.Green;
			}
			City1.Text = "TOKYO";
			Goingprice1.Text = g.current_value;

			if (Display1)
			{
				Probability1.Text = g.previous_value;
				Display = false;
			}
			else {
				Probability1.Text = g.previous_value1;
				Display = true;
			}

		}


        /// <summary>
        /// Updates the privatedata.
        /// </summary>
        /// <returns>The privatedata.</returns>
        private async Task UpdatePrivatedata()
        {
            int index = 0;
            double TotalAssetprice = 0.0;

            // UTF8のファイルの読み込み Edit.        
            //string response = await saveLoadCS.DataLoadAsync();//登録データ読み込み         
			List<Price> prices =   await Finance.Parse( );//登録データセット

			foreach (Price price in prices)
			{

				TotalAssetprice = TotalAssetprice + Convert.ToDouble(price.Stocks * price.Itemprice);//保有数*購入価格
			}
			TotalAsset.Text = Convert.ToString(TotalAssetprice);

            index = index + 1;
    	}
        



        /// <summary>
        /// Privatedata this instance.
        /// </summary>
        private async Task Privatedata()
        {
            int index = 0;
            int count = 0;
            int i = 0;
            string namecode;

            // UTF8のファイルの読み込み Edit.        
           	//string response = await saveLoadCS.DataLoadAsync();//登録データ読み込み
            // string[] rows = response.Replace("\n,", "\n").Split('\n'); //\n split 

          
			List<Price> prices = await Finance.Parse();

            stack  = new StackLayout[prices.Count+1];//1=最下行追加分
           
            AddCity = new Label[prices.Count+1];
            AddGoingprice = new Label[prices.Count+1];
            UptoButtons = new Button[prices.Count+1];

            //Price price = new Price();



            foreach (Price price in prices)
            {
				namecode = price.Name;//rows[index].Substring(0, 4);

                //Nowprice = dataDisp.Getprice1(namecode);//コードを指定して現在値を得る（浮動小数点）
                //try
                //{
                    //dataDispの代替
                    //var str = await Download(namecode);//コードを指定して現在値を得る（浮動小数点）
                    bool str =  await Getserchi(namecode);
                   
                    AddCity[i] = new Label
                    {
                        Text = price.Name + price.Ask,//"Add"+ "1234",
                        WidthRequest = 250,
                        HorizontalTextAlignment = TextAlignment.Start,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontSize = 15
                    };
                    //ラベルタッチでイベントを発生させる
                    var tgr = new TapGestureRecognizer();
                    tgr.Tapped += (sender, e) => OnLabelClicked(sender, e ,i);
                    AddCity[i].GestureRecognizers.Add(tgr);

                    AddGoingprice[i] = new Label
                    {
                        Text = g.current_value,//"AddGoingprice",
                        WidthRequest = 250,
                        HorizontalTextAlignment = TextAlignment.End,
                        VerticalTextAlignment = TextAlignment.Center,
                        FontSize = 15
                    };

                    UptoButtons[i] = new Button
                    {
                        Text = g.previous_value,//"UptoAcet" + prices.Count,
                        WidthRequest = 80,
                        TextColor = Color.FromHex("FFFFFF"),
                        //BackgroundColor = Color.Red
                    };
                   // UptoButtons[i].Clicked += await uptoButtons_Clicked(null,null,price.Name);
             
                    stack[i] = new StackLayout();
                    stack[i].Orientation = StackOrientation.Horizontal;
                    stack[i].Children.Add(AddCity[i]);//Label
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
                WidthRequest = 250,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 15
            };
            //ラベルタッチでイベントを発生させる
            var tgrr = new TapGestureRecognizer();
            tgrr.Tapped += (sender, e) => OnLabelClicked(sender, e, i);
            AddCity[i].GestureRecognizers.Add(tgrr);

            AddGoingprice[i] = new Label
            {
                Text = "Non",
                WidthRequest = 250,
                HorizontalTextAlignment = TextAlignment.End,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 15
            };

            UptoButtons[i] = new Button
            {
                Text = "NonUptoAcet",
                WidthRequest = 80,
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
		/// Getserchi the specified code.
		/// </summary>
		/// <param name="code">Code.</param>
		public async Task<bool> Getserchi(string code)
		{
			string TrgetWord = null, TrgetWord1 = null, TrgetWord2 = null;
			string[] al = new string[2];
			bool polarity = true;


			string url = "http://stocks.finance.yahoo.co.jp/stocks/detail/?code=" + code;// +".T";

			var httpClient = new HttpClient();
			string str =await httpClient.GetStringAsync(url);

			//List<Price> prices = Finance.Parse(code);
			//List<Price> prices = new List<Price>();

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
					al[0] = "Error";
				}

				string searchWord1 = "yjMSt"; //検索する文字列前日比
				int foundIndex1 = str.IndexOf(searchWord1);//始めの位置を探す
				int i1 = searchWord1.Length + 2;

				for (; Convert.ToString(str[foundIndex1 + i1]) != "（"; i1++)
				{
					TrgetWord1 = TrgetWord1 + str[foundIndex1 + i1];//previous 前日比? ¥
				}

				if (Convert.ToString(str[foundIndex1 + i1 + 1]) == "-")//(－)下落
				{
					polarity = false;
				}


				i1++;
				for (; Convert.ToString(str[foundIndex1 + i1]) != "）"; i1++)
				{
					TrgetWord2 = TrgetWord2 + str[foundIndex1 + i1];//previous 前日比? %
				}
				al[0] = Convert.ToString(polarity); //TrgetWord;//return code
				al[1] = TrgetWord1;//return price

				Price price = new Price();

				//price.Bid = Convert.ToDecimal(TrgetWord);// 現在値
				//price.TotalAsset = price.Realprice * Convert.ToDouble(price.Stocks);//現在評価額合計
				price.Ask = 999999;
				//price.Stocks =//保有数
				//price.Itemprice = //購入単価	
					     
				g.current_value = TrgetWord;// 現在値
				g.previous_value = TrgetWord1;
				g.previous_value1 = TrgetWord2;

				return polarity;
			}catch(Exception e)
			{
				var accepted = await DisplayAlert(e.Message,"市場が開始していません。", "Ok","Cancel");
				if (accepted== true)
				{
					Application.Current.MainPage = new WebSerchi();
					//Navigation.InsertPageBefore(new WebSerchi(), this);
					//buttonDialog1.Text = "Accepted!";
					//break;
				}

			}
			return polarity;
		}//class to end	

		public class Getvalue
		{
			public string current_value { get; set; }//現在値
			public string previous_value { get; set; }//前日比¥
			public string previous_value1 { get; set; }//前日比+-
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
					var notuse_UpdateNewYork = UpdateNewYork();
					var notuse_UpdateTokyo = UpdateTokyo();
					var notuse_UpdatePrivatedata = UpdatePrivatedata();
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
}
