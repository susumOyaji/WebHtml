using System;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
//using System.Text;
using System.Collections.Generic;
using System.Diagnostics;


namespace WebHtml
{
	public partial class MainDisplay:ContentPage
	{
			bool Display, Display1 = true;
			Price price = new Price();
			//Getvalue g = new Getvalue();
			Button timerButton = new Button();
			TextCell timer = new TextCell();
			Label City = new Label();
			Label Goingprice = new Label();
			Button Probability = new Button();
			Label City1 = new Label();
			Label Goingprice1 = new Label();
			Button Probability1 = new Button();
			Label TotalAsset = new Label();
			StackLayout Baselayout = new StackLayout();
			string[,] EntryData = new string[3, 3];
			Entry usercode, usercost, usershares;



		public MainDisplay()
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


			var status = new Label();
			var html = new Label
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand,
				LineBreakMode = LineBreakMode.WordWrap,
				Font = Font.SystemFontOfSize(NamedSize.Small),
			};

			City = new Label
			{
				Text = "City",
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
			Probability = new Button { Text = "Probability", TextColor = Color.FromHex("FFFFFF"), WidthRequest = 80,/* BackgroundColor = Color.Red*/ };


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
			Probability1 = new Button { Text = "Probability", TextColor = Color.FromHex("FFFFFF"), WidthRequest = 80, BackgroundColor = Color.Red };


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


			StackLayout Toplayout = new StackLayout
			{
				Spacing = 0,
				Children = { Date, NewyorkLayout, TokyoLayout, AssetLayout, timerButton, html }
			};




			int count = 1;
			StackLayout[] stack = new StackLayout[count];
			StackLayout Allstack = new StackLayout();

			//ボタンコントロール配列のフィールドを作成
			Button[] UptoButtons = new Button[count];
			Label[] AddCity = new Label[count];
			Label[] AddGoingprice = new Label[count];

			var scroll = new ScrollView();
			//Content = scroll;
			for (int i = 0; i < (UptoButtons.Length); i++)
			{
				//インスタンス
				AddCity[i] = new Label
				{
					Text = "Add",// + i,
					WidthRequest = 250,
					HorizontalTextAlignment = TextAlignment.Start,
					VerticalTextAlignment = TextAlignment.Center,
					FontSize = 15
				};
				//ラベルタッチでイベントを発生させる
				var tgr = new TapGestureRecognizer();
				tgr.Tapped += (sender, e) => OnLabelClicked(sender, e);
				AddCity[i].GestureRecognizers.Add(tgr);

				AddGoingprice[i] = new Label
				{
					Text = "AddGoingprice",
					WidthRequest = 250,
					HorizontalTextAlignment = TextAlignment.Start,
					VerticalTextAlignment = TextAlignment.Center,
					FontSize = 15
				};

				UptoButtons[i] = new Button
				{
					Text = "UptoAcet" + i,
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

			}//for to end





			//Price p = new Price();

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
			WebSerchi.UpdateNewYork();
			WebSerchi.UpdateTokyo();
			Reloadtime(1);

		}//mthod to end






		public void Reloadtime(int Sec)
		{
			timerButton.Text = "timer running...";
			Device.StartTimer(new TimeSpan(0, 0, Sec), () =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					// interact with UI elements
					timerButton.Text = DateTime.Now.ToString("mm:ss") + " past the hour";
					WebSerchi.UpdateNewYork();
					WebSerchi.UpdateTokyo();

				});
				return true; // runs again, or false to stop
			});
		}

		private void OnLabelClicked(object sender, EventArgs e)
		{
			var str = ((Label)sender).Text;
			TotalAsset.Text = str;
			//DisplayAlert("Tapped", str + " is Tapped", "OK");

			usercode = new Entry { Placeholder = "Code", Keyboard = Keyboard.Text, };
			usercode.Text = "";

			usercost = new Entry { Placeholder = "Cost", Keyboard = Keyboard.Numeric };
			usercost.Text = "";

			usershares = new Entry { Placeholder = "Shares", Keyboard = Keyboard.Numeric };
			usershares.Text = "";

			Button submit = new Button { BackgroundColor = Color.Red, Text = "Save" };
			submit.Clicked += Entry_Completed;

			Content = new StackLayout
			{
				Padding = 20,
				VerticalOptions = LayoutOptions.Start,
				Children = { usercode, usercost, usershares, submit }
			};

		}

		

		void Entry_Completed(object sender, EventArgs e)
		{
			string Usercode = usercode.Text;
			string Usercost = usercost.Text;
			string Usershares = usershares.Text;

			if (Usercode == "" ^ Usershares == "" ^ Usershares == "")
			{
				DisplayAlert("failed", " is InputData", "OK");
			}
			else {
				//usercode.Text = "Code or Cost or Usershares failed";
				//usercost.Text = "Code or Cost or Usershares failed";
				DisplayAlert("SAVE", " is InputData", "OK");
				Application.Current.MainPage = new WebSerchi();
			}
		}






	}//clasee to end



}
