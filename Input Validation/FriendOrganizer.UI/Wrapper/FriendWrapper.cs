using FriendOrganizer.Model;
using System;
using System.Runtime.CompilerServices;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model)
        {
        }

        public int Id { get { return Model.Id; } }

        public string FirstName
        {
            get { return GetValue<string>(nameof(FirstName)); }
            set
            {
                SetValue(value);
                ValidateProperty(nameof(FirstName));
                //set { SetValue(value, nameof(LastName)); }   // OR 
                //set { SetValue<string>(value, nameof(LastName)); }  // OR 
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
            get { return GetValue<string>(nameof(LastName)); }
            set { SetValue(value); }
        }


        public string Email
        {
            get { return Model.Email; }
            set
            {
                SetValue(value);
            }
        }
    }
}
