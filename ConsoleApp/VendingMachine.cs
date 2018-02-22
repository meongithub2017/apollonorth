using System;

namespace ApolloNorth
{
    public class VendingMachine
    {
        #region Private Members

        //private int numofCan;
        //private double accountBalance;
        //private string currentPin, suppliedPin;
        
        #endregion

        #region Constant

        const double PRICEOFITEM = 50;
        const int INVENTORY = 25;

        #endregion

        #region Constructor
        public VendingMachine()
        {
            // Set initial values
            NumberOfCan = 1;
            AccountBalance = 100;
            Card1Pin = "01234";
            Card2Pin = "56789";
            SuppliedPin = string.Empty;
        }

        public VendingMachine(int inventory, int accountAmount)
        {
            // Set initial values
            NumberOfCan = inventory;             //0,1,25,100
            AccountBalance = accountAmount;      //0,50,250,0
            Card1Pin = "01234";
            Card2Pin = "56789";
            SuppliedPin = string.Empty;
        }

        #endregion

        #region Public Properties
        public int NumberOfCan
        {
            get;
            set;
        }
        public double AccountBalance
        {
            get;
            set;
        }
        public int CashCardBalance
        {
            get;
            set;
        }

        public string Card1Pin
        {
            get;
            set;
        }
        public string  Card2Pin
        {
            get;
            set;
        }
        public string SuppliedPin
        {
            get;
            set;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Buy Drink 
        /// </summary>
        /// <returns></returns>
        public string BuyDrink()
        {
            try
            {
                string response = CheckDetail();
                if (response.Equals("OK"))
                {
                    UpdateInventory();
                    DeductAmount();

                    return string.Format("CAN Dispensed. "+ Environment.NewLine + "Remaining CAN: {0}  Account Balance: {1}p",
                        NumberOfCan, AccountBalance);

                    //return "Remaining CAN: " + _numofCan + " Card Balance: " + _cashCardBalance;
                   
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            return string.Format("Total Inventory: {0}      Account Amount: {1}p", NumberOfCan,
                AccountBalance);
        }

        /// <summary>
        /// Validate User Pin
        /// </summary>
        /// <returns></returns>
        public string ValidatePin()
        {
            //if (!_currentPin.Equals(_suppliedPin, System.StringComparison.InvariantCultureIgnoreCase))

            if (!SuppliedPin.Equals(Card1Pin, System.StringComparison.InvariantCultureIgnoreCase) 
                && !SuppliedPin.Equals(Card2Pin, System.StringComparison.InvariantCultureIgnoreCase))
                return "Invalid Card Pin";

            return "OK";
        }  
        
        #endregion

        #region Private Methods

        /// <summary>
        /// Check Inventory, Account Balance and Other Details
        /// </summary>
        private string CheckDetail()
        {
            //Can’t vend more than 25 cans
            if (NumberOfCan <= 0 || NumberOfCan > INVENTORY)
                return "Inventory Out of Stock";

            //Can’t vend can if less than 50p on the card 
            if (AccountBalance < PRICEOFITEM)
                return "Insufficient fund in Account";

            //PIN supplied is invalid
            ////if (!_currentPin.Equals(_suppliedPin))
            ////    return "Invalid Card Pin !!!.";

            return "OK";
        }

        /// <summary>
        /// Update Inventory Quantity in a Machine
        /// </summary>
        private void UpdateInventory()
        {
            if (NumberOfCan > 0)
                NumberOfCan = NumberOfCan - 1;
        }

        /// <summary>
        /// Update Balance Calculation
        /// </summary>
        private void DeductAmount()
        {
            //Cash card balance should be updated when a can is bought
            //As there are multiple cash cards linked to one account, the account may be accessed at the same time

            //"Buy drink, Deduct 50p from Account"
            if (AccountBalance >= PRICEOFITEM)
            {
                AccountBalance = AccountBalance - PRICEOFITEM;
                //return "Thank you for purchasing drink";
            }
            else if (AccountBalance < PRICEOFITEM)
            {
                //return "You do not have enough credit to purchase a drink";
            }
        }

        /// <summary>
        /// Get Vending Machine Inventory of 25 Cans
        /// </summary>
        private void GetInventory()
        {
            //string[,] drinkDesc = new string[,] {
            //    {"CAN", "50.00", "25"},
            //    {"Lemon Lime", "10.00", "20"},
            //    {"Grape Soda", "10.50", "20"},
            //    {"Cream Soda", "10.50", "20"}
            //};

        }


        #endregion
    }
}
