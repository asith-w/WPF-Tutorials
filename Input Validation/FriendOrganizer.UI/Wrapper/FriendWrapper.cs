using FriendOrganizer.Model;
using System;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : NotifyDataErrorInfoBase
    {
        public FriendWrapper(Friend model)
        {
            Model = model;
        }

        public Friend Model
        {
            get;
        }

        public int Id { get { return Model.Id; } }

        public string FirstName
        {
            get { return Model.FirstName; }
            set
            {
                Model.FirstName = value;
                OnPropertyChanged();
                ValidateProperty(nameof(FirstName));
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearError(propertyName);
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, "rob", StringComparison.OrdinalIgnoreCase))
                    {
                        AddErrors(propertyName, "this is a error");
                    }
                    break;
            }
            //throw new NotImplementedException();
        }

        public string LastName
        {
            get { return Model.LastName; }
            set
            {
                Model.LastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return Model.Email; }
            set
            {
                Model.Email = value;
                OnPropertyChanged();
            }
        }

        

    }









    public class ModelWrapper<T>
    {
        public ModelWrapper(T model)
        {
            Model = _model;
        }
        private T _model;
        public T Model { get; }
    }

    //public string FirstName
    //{
    //    get { return Model.FirstName; }
    //    set
    //    {
    //        Model.FirstName = value;
    //        OnPropertyChanged();
    //    }
    //}
}
