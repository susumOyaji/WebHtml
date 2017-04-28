using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Emit;
//using System.Text;
using System.Threading;
using System.Threading.Tasks;

using PCLStorage;
using Xamarin.Forms;

namespace WebHtml
{
    public  partial   class SaveLoadCS : ContentPage
    {
         
        //public string FilePath = "Users/sumitomoshigeru/Projects/";
        //Task<IFolder> rootFolder = FileSystem.Current.GetFolderFromPathAsync("Users/sumitomoshigeru/Projects/");
        //Task<IFolder>



        IFolder rootFolder = FileSystem.Current.LocalStorage;
        Entry entry;
        Label loadedLabel;
		//string name;

        public SaveLoadCS()
        {
            entry = new Entry
            {
                Placeholder = "Please input your name"
            };
            var saveButton = new Button
            {
                Text = "Save",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            saveButton.Clicked += SaveButton_Clicked;
            var loadButton = new Button
            {
                Text = "Load",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            loadButton.Clicked += LoadButton_Clicked;
            var deleteButton = new Button
            {
                Text = "Delete",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            deleteButton.Clicked += DeleteButton_Clicked;
            loadedLabel = new Label
            {
                Text = "Saved text will be displayed here when loaded."
            };

            Content = new StackLayout
            {
                Children = {
                    entry,
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            saveButton,
                            loadButton,
                            deleteButton
                        }
                    },
                    loadedLabel
                }
            };
        }


		public async Task DataSaveAsync(string savedata)
		{ 
			 IFile file = await rootFolder.CreateFileAsync("name.txt", CreationCollisionOption.ReplaceExisting);
			await file.WriteAllTextAsync(savedata);
		}





		private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            IFile file = await rootFolder.CreateFileAsync("name.txt", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(entry.Text);
        }

        
		public async  Task<string> DataLoadAsync( )
		{
			string name;
			ExistenceCheckResult res = await rootFolder.CheckExistsAsync("name.txt");
			if (res == ExistenceCheckResult.FileExists)
			{
				IFile file = await rootFolder.GetFileAsync("name.txt");
				name = await file.ReadAllTextAsync();
				//return name;
				}
			else
			{
				//ファイル作成
				IFile file = await rootFolder.CreateFileAsync("name.txt", CreationCollisionOption.ReplaceExisting);
				await file.WriteAllTextAsync(entry.Text);
				//ファイル読み込み
				file = await rootFolder.GetFileAsync("name.txt");
				name = await file.ReadAllTextAsync();
				//return name;
				await DisplayAlert("Error", "File is not found", "OK");
				//await DisplayAlert("Error1", "File is not found", "OK");
				//return Convert.ToString(file);
                //return name;
			}
			return name;
		}


		private  async void LoadButton_Clicked(object sender, EventArgs e)
        {
            ExistenceCheckResult res = await rootFolder.CheckExistsAsync("name.txt");
            if (res == ExistenceCheckResult.FileExists)
            {
                IFile file = await rootFolder.GetFileAsync("name.txt");
                string name = await file.ReadAllTextAsync();
                loadedLabel.Text = name;
            }
            else
            {
                await DisplayAlert("Error", "File is not found", "OK");
            }

        }


        public async Task DataDeleteAsync()
        {
            ExistenceCheckResult res = await rootFolder.CheckExistsAsync("name.txt");
            if (res == ExistenceCheckResult.FileExists)
            {
                IFile file = await rootFolder.GetFileAsync("name.txt");
                await file.DeleteAsync();
            }
        }

        public async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            ExistenceCheckResult res = await rootFolder.CheckExistsAsync("name.txt");
            if (res == ExistenceCheckResult.FileExists)
            {
                IFile file = await rootFolder.GetFileAsync("name.txt");
                await file.DeleteAsync();
                //loadedLabel.Text = "";
            }
        }

    }
}
