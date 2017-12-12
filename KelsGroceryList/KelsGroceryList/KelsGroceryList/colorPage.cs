using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCLStorage;
using Xamarin.Forms;

namespace KelsGroceryList
{
    public class colorPage : ContentPage
    {
        public colorPage()
        {
            var scrollMe = new ScrollView();

            var layout = new StackLayout { Padding = new Thickness(30) };

            scrollMe.Content = layout;
            this.Content = scrollMe;

            var label = new Button { BackgroundColor = Color.Transparent, TextColor = Color.Black, 
                Text = "Transparent", HorizontalOptions = LayoutOptions.Fill };
            var label2 = new Button { BackgroundColor = Color.AntiqueWhite, TextColor = Color.AntiqueWhite.Luminosity < .50 ? Color.White : Color.Black, Text = "AntiqueWhite" }; 
            var label3 = new Button { BackgroundColor = Color.Aqua, TextColor = Color.Aqua.Luminosity < .50 ? Color.White : Color.Black, Text = "Aqua" }; 
            var label4 = new Button { BackgroundColor = Color.Aquamarine, TextColor = Color.Aquamarine.Luminosity < .50 ? Color.White : Color.Black, Text = "Aquamarine" }; 
            var label5 = new Button { BackgroundColor = Color.LightGreen, TextColor = Color.LightGreen.Luminosity < .50 ? Color.White : Color.Black, Text = "LightGreen" }; 
            var label6 = new Button { BackgroundColor = Color.MidnightBlue, TextColor = Color.MidnightBlue.Luminosity < .50 ? Color.White : Color.Black, Text = "MidnightBlue" }; 
            var label7 = new Button { BackgroundColor = Color.Bisque, TextColor = Color.Bisque.Luminosity < .50 ? Color.White : Color.Black, Text = "Bisque" }; 
            var label8 = new Button { BackgroundColor = Color.Black, TextColor = Color.White, Text = "Black" }; 
            var label9 = new Button { BackgroundColor = Color.Salmon, TextColor = Color.Salmon.Luminosity < .50 ? Color.White : Color.Black, Text = "Salmon" }; 
            var label1 = new Button { BackgroundColor = Color.Blue, TextColor = Color.White, Text = "Blue" }; 
            var labela = new Button { BackgroundColor = Color.MediumSlateBlue, TextColor = Color.MediumSlateBlue.Luminosity < .50 ? Color.White : Color.Black, Text = "MediumSlateBlue" }; 
            var labelb = new Button { BackgroundColor = Color.Brown, TextColor = Color.Brown.Luminosity < .50 ? Color.White : Color.Black, Text = "Brown" }; 
            var labelc = new Button { BackgroundColor = Color.Orchid, TextColor = Color.Orchid.Luminosity < .50 ? Color.White : Color.Black, Text = "Orchid" }; 
            var labeld = new Button { BackgroundColor = Color.CadetBlue, TextColor = Color.CadetBlue.Luminosity < .50 ? Color.White : Color.Black, Text = "CadetBlue" }; 
            var labele = new Button { BackgroundColor = Color.Chartreuse, TextColor = Color.Chartreuse.Luminosity < .50 ? Color.White : Color.Black, Text = "Chartreuse" }; 
            var labelf = new Button { BackgroundColor = Color.Chocolate, TextColor = Color.Chocolate.Luminosity < .50 ? Color.White : Color.Black, Text = "Chocolate" }; 
            var labelg = new Button { BackgroundColor = Color.Coral, TextColor = Color.Coral.Luminosity < .50 ? Color.White : Color.Black, Text = "Coral" }; 
            var labelh = new Button { BackgroundColor = Color.CornflowerBlue, TextColor = Color.CornflowerBlue.Luminosity < .50 ? Color.White : Color.Black, Text = "CornflowerBlue" }; 
            var labeli = new Button { BackgroundColor = Color.Olive, TextColor = Color.Olive.Luminosity < .50 ? Color.White : Color.Black, Text = "Olive" }; 
            var labelj = new Button { BackgroundColor = Color.Crimson, TextColor = Color.Crimson.Luminosity < .50 ? Color.White : Color.Black, Text = "Crimson" }; 
            var labelk = new Button { BackgroundColor = Color.Teal, TextColor = Color.Teal.Luminosity < .50 ? Color.White : Color.Black, Text = "Teal" }; 
            var labell = new Button { BackgroundColor = Color.DarkBlue, TextColor = Color.DarkBlue.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkBlue" }; 
            var labelm = new Button { BackgroundColor = Color.DarkCyan, TextColor = Color.DarkCyan.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkCyan" }; 
            var labeln = new Button { BackgroundColor = Color.DarkGoldenrod, TextColor = Color.DarkGoldenrod.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkGoldenrod" }; 
            var labelo = new Button { BackgroundColor = Color.DarkGray, TextColor = Color.DarkGray.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkGray" }; 
            var labelp = new Button { BackgroundColor = Color.DarkGreen, TextColor = Color.DarkGreen.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkGreen" }; 
            var labelq = new Button { BackgroundColor = Color.DarkKhaki, TextColor = Color.DarkKhaki.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkKhaki" }; 
            var labelr = new Button { BackgroundColor = Color.DarkMagenta, TextColor = Color.DarkMagenta.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkMagenta" }; 
            var labels = new Button { BackgroundColor = Color.DarkOliveGreen, TextColor = Color.DarkOliveGreen.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkOliveGreen" }; 
            var labelt = new Button { BackgroundColor = Color.DarkOrange, TextColor = Color.DarkOrange.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkOrange" }; 
            var labelu = new Button { BackgroundColor = Color.DarkOrchid, TextColor = Color.DarkOrchid.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkOrchid" }; 
            var labelv = new Button { BackgroundColor = Color.DarkRed, TextColor = Color.DarkRed.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkRed" }; 
            var labelw = new Button { BackgroundColor = Color.DarkSalmon, TextColor = Color.DarkSalmon.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkSalmon" }; 
            var labelx = new Button { BackgroundColor = Color.DarkSeaGreen, TextColor = Color.DarkSeaGreen.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkSeaGreen" }; 
            var labely = new Button { BackgroundColor = Color.DarkSlateBlue, TextColor = Color.DarkSlateBlue.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkSlateBlue" }; 
            var labelz = new Button { BackgroundColor = Color.DarkSlateGray, TextColor = Color.DarkSlateGray.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkSlateGray" }; 
            var labelaa = new Button { BackgroundColor = Color.DarkTurquoise, TextColor = Color.DarkTurquoise.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkTurquoise" }; 
            var labelbb = new Button { BackgroundColor = Color.DarkViolet, TextColor = Color.DarkViolet.Luminosity < .50 ? Color.White : Color.Black, Text = "DarkViolet" }; 
            var labelcc = new Button { BackgroundColor = Color.DeepPink, TextColor = Color.DeepPink.Luminosity < .50 ? Color.White : Color.Black, Text = "DeepPink" }; 
            var labeldd = new Button { BackgroundColor = Color.DeepSkyBlue, TextColor = Color.DeepSkyBlue.Luminosity < .50 ? Color.White : Color.Black, Text = "DeepSkyBlue" }; 
            var labelgg = new Button { BackgroundColor = Color.DodgerBlue, TextColor = Color.DodgerBlue.Luminosity < .50 ? Color.White : Color.Black, Text = "DodgerBlue" }; 
            var labelhh = new Button { BackgroundColor = Color.Firebrick, TextColor = Color.Firebrick.Luminosity < .50 ? Color.White : Color.Black, Text = "Firebrick" }; 
            var labelii = new Button { BackgroundColor = Color.FloralWhite, TextColor = Color.FloralWhite.Luminosity < .50 ? Color.White : Color.Black, Text = "FloralWhite" }; 
            var labeljj = new Button { BackgroundColor = Color.ForestGreen, TextColor = Color.ForestGreen.Luminosity < .50 ? Color.White : Color.Black, Text = "ForestGreen" }; 
            var labelkk = new Button { BackgroundColor = Color.Fuchsia, TextColor = Color.Fuchsia.Luminosity < .50 ? Color.White : Color.Black, Text = "Fuchsia" }; 
            var labelmm = new Button { BackgroundColor = Color.LightPink, TextColor = Color.LightPink.Luminosity < .50 ? Color.White : Color.Black, Text = "LightPink" }; 
            var labelnn = new Button { BackgroundColor = Color.Gold, TextColor = Color.Gold.Luminosity < .50 ? Color.White : Color.Black, Text = "Gold" }; 
            var labeloo = new Button { BackgroundColor = Color.Goldenrod, TextColor = Color.Goldenrod.Luminosity < .50 ? Color.White : Color.Black, Text = "Goldenrod" }; 
            var labelpp = new Button { BackgroundColor = Color.Gray, TextColor = Color.Gray.Luminosity < .50 ? Color.White : Color.Black, Text = "Gray" }; 
            var labelqq = new Button { BackgroundColor = Color.Green, TextColor = Color.Green.Luminosity < .50 ? Color.White : Color.Black, Text = "Green" }; 
            var labelrr = new Button { BackgroundColor = Color.LightGreen, TextColor = Color.AntiqueWhite.Luminosity < .50 ? Color.White : Color.Black, Text = "AntiqueWhite" }; 
            var labelss = new Button { BackgroundColor = Color.Red, TextColor = Color.Red.Luminosity < .50 ? Color.White : Color.Black, Text = "Red" }; 
            var labeltt = new Button { BackgroundColor = Color.HotPink, TextColor = Color.HotPink.Luminosity < .50 ? Color.White : Color.Black, Text = "HotPink" }; 
            var labeluu = new Button { BackgroundColor = Color.OrangeRed, TextColor = Color.OrangeRed.Luminosity < .50 ? Color.White : Color.Black, Text = "OrangeRed" }; 
            var labelvv = new Button { BackgroundColor = Color.Orange, TextColor = Color.Orange.Luminosity < .50 ? Color.White : Color.Black, Text = "Orange" }; 
            var labelww = new Button { BackgroundColor = Color.SkyBlue, TextColor = Color.SkyBlue.Luminosity < .50 ? Color.White : Color.Black, Text = "SkyBlue" }; 
            var labelxx = new Button { BackgroundColor = Color.Khaki, TextColor = Color.Khaki.Luminosity < .50 ? Color.White : Color.Black, Text = "Khaki" }; 
            var labelyy = new Button { BackgroundColor = Color.Lavender, TextColor = Color.Lavender.Luminosity < .50 ? Color.White : Color.Black, Text = "Lavender" }; 
            var labelzz = new Button { BackgroundColor = Color.LavenderBlush, TextColor = Color.LavenderBlush.Luminosity < .50 ? Color.White : Color.Black, Text = "LavenderBlush" }; 
            var label11 = new Button { BackgroundColor = Color.Violet, TextColor = Color.Violet.Luminosity < .50 ? Color.White : Color.Black, Text = "Violet" }; 
            var label22 = new Button { BackgroundColor = Color.Yellow, TextColor = Color.Yellow.Luminosity < .50 ? Color.White : Color.Black, Text = "Yellow" }; 
            var label33 = new Button { BackgroundColor = Color.LightBlue, TextColor = Color.LightBlue.Luminosity < .50 ? Color.White : Color.Black, Text = "LightBlue" }; 
            var label44 = new Button { BackgroundColor = Color.LightCoral, TextColor = Color.LightCoral.Luminosity < .50 ? Color.White : Color.Black, Text = "LightCoral" }; 
            var label55 = new Button { BackgroundColor = Color.LightCyan, TextColor = Color.LightCyan.Luminosity < .50 ? Color.White : Color.Black, Text = "LightCyan" }; 
            var label66 = new Button { BackgroundColor = Color.LightGoldenrodYellow, TextColor = Color.LightGoldenrodYellow.Luminosity < .50 ? Color.White : Color.Black, Text = "LightGoldenrodYellow" }; 
            var label77 = new Button { BackgroundColor = Color.LightGray, TextColor = Color.LightGray.Luminosity < .50 ? Color.White : Color.Black, Text = "LightGray" }; 

            label.Clicked += new EventHandler(MyButtonClick);
            label2.Clicked += new EventHandler(MyButtonClick);
            label3.Clicked += new EventHandler(MyButtonClick);
            label4.Clicked += new EventHandler(MyButtonClick);
            label5.Clicked += new EventHandler(MyButtonClick);
            label6.Clicked += new EventHandler(MyButtonClick);
            label7.Clicked += new EventHandler(MyButtonClick);
            label8.Clicked += new EventHandler(MyButtonClick);
            label9.Clicked += new EventHandler(MyButtonClick);
            label1.Clicked += new EventHandler(MyButtonClick);
            labela.Clicked += new EventHandler(MyButtonClick);
            labelb.Clicked += new EventHandler(MyButtonClick);
            labelc.Clicked += new EventHandler(MyButtonClick);
            labeld.Clicked += new EventHandler(MyButtonClick);
            labele.Clicked += new EventHandler(MyButtonClick);
            labelf.Clicked += new EventHandler(MyButtonClick);
            labelg.Clicked += new EventHandler(MyButtonClick);
            labelh.Clicked += new EventHandler(MyButtonClick);
            labeli.Clicked += new EventHandler(MyButtonClick);
            labelj.Clicked += new EventHandler(MyButtonClick);
            labelk.Clicked += new EventHandler(MyButtonClick);
            labell.Clicked += new EventHandler(MyButtonClick);
            labelm.Clicked += new EventHandler(MyButtonClick);
            labeln.Clicked += new EventHandler(MyButtonClick);
            labelo.Clicked += new EventHandler(MyButtonClick);
            labelp.Clicked += new EventHandler(MyButtonClick);
            labelq.Clicked += new EventHandler(MyButtonClick);
            labelr.Clicked += new EventHandler(MyButtonClick);
            labels.Clicked += new EventHandler(MyButtonClick);
            labelt.Clicked += new EventHandler(MyButtonClick);
            labelu.Clicked += new EventHandler(MyButtonClick);
            labelv.Clicked += new EventHandler(MyButtonClick);
            labelw.Clicked += new EventHandler(MyButtonClick);
            labelx.Clicked += new EventHandler(MyButtonClick);
            labely.Clicked += new EventHandler(MyButtonClick);
            labelz.Clicked += new EventHandler(MyButtonClick);
            labelaa.Clicked += new EventHandler(MyButtonClick);
            labelbb.Clicked += new EventHandler(MyButtonClick);
            labelcc.Clicked += new EventHandler(MyButtonClick);
            labeldd.Clicked += new EventHandler(MyButtonClick);
            labelgg.Clicked += new EventHandler(MyButtonClick);
            labelhh.Clicked += new EventHandler(MyButtonClick);
            labelii.Clicked += new EventHandler(MyButtonClick);
            labeljj.Clicked += new EventHandler(MyButtonClick);
            labelkk.Clicked += new EventHandler(MyButtonClick);
            labelmm.Clicked += new EventHandler(MyButtonClick);
            labelnn.Clicked += new EventHandler(MyButtonClick);
            labeloo.Clicked += new EventHandler(MyButtonClick);
            labelpp.Clicked += new EventHandler(MyButtonClick);
            labelqq.Clicked += new EventHandler(MyButtonClick);
            labelrr.Clicked += new EventHandler(MyButtonClick);
            labelss.Clicked += new EventHandler(MyButtonClick);
            labeltt.Clicked += new EventHandler(MyButtonClick);
            labeluu.Clicked += new EventHandler(MyButtonClick);
            labelvv.Clicked += new EventHandler(MyButtonClick);
            labelww.Clicked += new EventHandler(MyButtonClick);
            labelxx.Clicked += new EventHandler(MyButtonClick);
            labelyy.Clicked += new EventHandler(MyButtonClick);
            labelzz.Clicked += new EventHandler(MyButtonClick);
            label11.Clicked += new EventHandler(MyButtonClick);
            label22.Clicked += new EventHandler(MyButtonClick);
            label33.Clicked += new EventHandler(MyButtonClick);
            label44.Clicked += new EventHandler(MyButtonClick);
            label55.Clicked += new EventHandler(MyButtonClick);
            label66.Clicked += new EventHandler(MyButtonClick);
            label77.Clicked += new EventHandler(MyButtonClick);

            layout.Children.Add(label);
            layout.Children.Add(label2);
            layout.Children.Add(label3);
            layout.Children.Add(label4);
            layout.Children.Add(label5);
            layout.Children.Add(label6);
            layout.Children.Add(label7);
            layout.Children.Add(label8);
            layout.Children.Add(label9);
            layout.Children.Add(label1);
            layout.Children.Add(labela);
            layout.Children.Add(labelb);
            layout.Children.Add(labelc);
            layout.Children.Add(labeld);
            layout.Children.Add(labele);
            layout.Children.Add(labelf);
            layout.Children.Add(labelg);
            layout.Children.Add(labelh);
            layout.Children.Add(labeli);
            layout.Children.Add(labelj);
            layout.Children.Add(labelk);
            layout.Children.Add(labell);
            layout.Children.Add(labelm);
            layout.Children.Add(labeln);
            layout.Children.Add(labelo);
            layout.Children.Add(labelp);
            layout.Children.Add(labelq);
            layout.Children.Add(labelr);
            layout.Children.Add(labels);
            layout.Children.Add(labelt);
            layout.Children.Add(labelu);
            layout.Children.Add(labelv);
            layout.Children.Add(labelw);
            layout.Children.Add(labelx);
            layout.Children.Add(labely);
            layout.Children.Add(labelz);
            layout.Children.Add(labelaa);
            layout.Children.Add(labelbb);
            layout.Children.Add(labelcc);
            layout.Children.Add(labeldd);
            layout.Children.Add(labelgg);
            layout.Children.Add(labelhh);
            layout.Children.Add(labelii);
            layout.Children.Add(labeljj);
            layout.Children.Add(labelkk);
            layout.Children.Add(labelmm);
            layout.Children.Add(labelnn);
            layout.Children.Add(labeloo);
            layout.Children.Add(labelpp);
            layout.Children.Add(labelqq);
            layout.Children.Add(labelrr);
            layout.Children.Add(labelss);
            layout.Children.Add(labeltt);
            layout.Children.Add(labeluu);
            layout.Children.Add(labelvv);
            layout.Children.Add(labelww);
            layout.Children.Add(labelxx);
            layout.Children.Add(labelyy);
            layout.Children.Add(labelzz);
            layout.Children.Add(label11);
            layout.Children.Add(label22);
            layout.Children.Add(label33);
            layout.Children.Add(label44);
            layout.Children.Add(label55);
            layout.Children.Add(label66);
            layout.Children.Add(label77);

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            GC.Collect();
        }

        public async void MyButtonClick(object sender, EventArgs e)
        {
            try
            {            
                Button button = sender as Button;
            
                App.Global.bgColor = button.BackgroundColor;

                if (button.BackgroundColor.Luminosity < .50 || button.BackgroundColor == Color.Blue)
                {
                    App.Global.textColor = Color.White;
                }
                else
                {
                    App.Global.textColor = Color.Black;
                }

                IFolder rootFolder = FileSystem.Current.LocalStorage;

                IFile myFile = await rootFolder.GetFileAsync("settingsp.txt");

                string newBGcolor = button.Text;
                string newTextColor = button.BackgroundColor.Luminosity < .50 ? "White" : "Black";
                if (button.BackgroundColor == Color.Blue)
                    newTextColor = "White";

                string textSize = "";

                if (App.Current.Resources["text_size"].ToString().Contains("12"))
                {
                    textSize = "Small";
                }
                else if (App.Current.Resources["text_size"].ToString().Contains("18"))
                {
                    textSize = "Medium";
                }
                else if (App.Current.Resources["text_size"].ToString().Contains("24"))
                {
                    textSize = "Large";
                }

                await myFile.WriteAllTextAsync("dbVersion1.dbColor" + newBGcolor + ".txtColor" + newTextColor + ".tutor" + (App.Global.isFirstRun ? "TRUE" : "FALSE") + ".txtSize" + textSize);

                await Application.Current.MainPage.Navigation.PopModalAsync(); //Remove the page currently on top.

                button = null;
                rootFolder = null;
                myFile = null;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error writing color data", ex.Message, "Ok");
            }
        }
    }
}