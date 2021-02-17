using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class OfficeLocation
    {
        private int locationId;
        private string locationName, street, town, county, postcode, telNo;


        public OfficeLocation()
        {
            locationId = 0;
            locationName = ""; street = ""; town = ""; county = ""; postcode = ""; telNo = "";
        }

        public OfficeLocation(int locationId, string locationName, string street, string town, string county, string postcode, string telNo)
        {
            this.locationId = locationId; this.locationName = locationName; this.street = street; 
            this.town = town; this.county = county; this.postcode = postcode; this.telNo = telNo;
        }
        

        public int LocationId
        {
            get { return locationId; }
            set { locationId = value; }
        }

        public string LocationName
        {
            get { return locationName; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validForename(value))
                {
                    locationName = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Location Name must be 2-20 letters.");
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                if (MyValidation.validLength(value, 5, 30) && MyValidation.validLetterNumberWhiteSpace(value))
                {
                    street = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Street must be 5-30 letters.");
            }
        }

        public string Town
        {
            get { return town; }
            set
            {
                if (MyValidation.validLength(value, 2, 30) && MyValidation.validLetterWhiteSpace(value))
                {
                    town = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Town must be 2-30 letters.");
            }
        }

        public string County
        {
            get { return county; }
            set
            {
                if (MyValidation.validLength(value, 2, 30) && MyValidation.validLetter(value))
                {
                    county = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("County must be 2-30 letters.");
            }
        }

        public string Postcode
        {
            get { return postcode; }
            set
            {
                if (MyValidation.validLength(value, 7, 8) && MyValidation.validLetterNumberWhiteSpace(value))
                {
                    postcode = MyValidation.EachLetterToUpper(value);
                }
                else
                    throw new MyException("Postcode must be 7-8 letters.");
            }
        }

        public string TelNo
        {
            get { return telNo; }
            set
            {
                if (MyValidation.validLength(value, 11, 15) && MyValidation.validNumber(value))
                {
                    telNo = value;
                }
                else
                    throw new MyException("Telephone number must be 11-15 digits.");
            }
        }
    }
}
