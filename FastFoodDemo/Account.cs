using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class Account
    {
        private int accountId;
        private string clientName, street, town, county,  postcode, telNo, email;

        public Account()
        {
            accountId = 0;
            clientName = ""; street = ""; town = ""; county = ""; postcode = "";telNo = ""; email = "";
        }

        public Account(int accountId, string clientName, string street, String town, String county,
             String postcode, String telNo, string email)
        {
            this.accountId = accountId;
            this.clientName = clientName;
            this.street = street; this.town = town; this.street = street; this.town = town;
            this.county = county; this.postcode = postcode; this.telNo = telNo; this.email = email;
        }

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public string ClientName
        {
            get { return clientName; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validSurname(value))
                {
                    clientName = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Client Name must be 2-20 letters.");
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                if (MyValidation.validLength(value, 5, 40) && MyValidation.validLetterNumberWhiteSpace(value))
                {
                    street = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Street must be 5-40 letters.");
            }
        }

        public string Town
        {
            get { return town; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetterWhiteSpace(value))
                {
                    town = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Town must be 2-20 letters.");
            }
        }

        public string County
        {
            get { return county; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetter(value))
                {
                    county = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("County must be 2-20 letters.");
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


        public String Email
        {
            get { return email; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validEmail(value))
                {
                    email = value;
                }
                else
                    throw new MyException("Email must be 2-20 characters");
            }

        }


    }



}
