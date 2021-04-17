using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace PeopleStoreApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string FirstName = string.Empty;
        string LastName = string.Empty;
        string PhoneNumber = string.Empty;
//        string BtnSave = string.Empty;
//        string BtnPhoto = string.Empty;


        public string Firstname
        {
            get => FirstName;
            set
            {
                if (FirstName == value)
                    return;
                FirstName = value;
                OnPropertyChangedFirstName(nameof(Firstname));
            }
        }
        public string Lastname
        {
            get => LastName;
            set
            {
                if (LastName == value)
                    return;
                LastName = value;
                OnPropertyChangedLastName(nameof(Lastname));
            }
        }

        public string Phonenumber
        {
            get => PhoneNumber;
            set
            {
                if (PhoneNumber == value)
                    return;
                PhoneNumber = value;
                OnPropertyChangedPhoneNumber(nameof(Phonenumber));
            }
        }

 /*       private async void btnSave(object sender, EventArgs e)
        {
            if (!Validate())
            {
                await DisplayAlert("Validation Error", "First name, last name, phone number and picture are required.", "Ok");
                return;
            }

            try
            {
                await client.AddPersonAsync(person);
                await DisplayAlert("Success", "Data has been saved.", "Ok");
                
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }

        }

        private bool Validate()
        {
            return !(string.IsNullOrWhiteSpace(FirstName) ||
                    string.IsNullOrWhiteSpace(LastName) ||
                    string.IsNullOrWhiteSpace(PhoneNumber) ||
                    string.IsNullOrWhiteSpace(PictureBase64)
                );
        }
 
        private async void btnPhoto_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {

            });

            if (photo == null)
                return;

            imgPhoto.Source = ImageSource.FromStream(() => photo.GetStream());
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                photo.GetStream().CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            string base64 = Convert.ToBase64String(bytes);
            person.PictureBase64 = base64;
        }

*/
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChangedFirstName(string FirstName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(FirstName));
        }

        void OnPropertyChangedLastName(string LastName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(LastName));
        }

        void OnPropertyChangedPhoneNumber(string PhoneNumber)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PhoneNumber));
        }
 /*       void OnPropertyChangedBtnSave(string BtnSave)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(BtnSave));
        }

        void OnPropertyChangedBtnPhoto(string BtnPhoto)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(BtnPhoto));
        }
 */
    }
}
