using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    // 1) declare enumeration CurrencyTypes, values UAH, USD, EU
    enum CurrencyTypes
    {
        UAH,
        USD,
        EU
    }

    class Money
    {
        // 2) declare 2 properties Amount, CurrencyType
        public decimal Amount { get; set; }
        public CurrencyTypes CurrencyTypes { get; set; }

        // 3) declare parameter constructor for properties initialization
        public Money(decimal amount)
        {
            Amount = amount;
        }
        public Money(decimal amount, CurrencyTypes currencyTypes)
        {
            Amount = amount;
            CurrencyTypes = currencyTypes;
        }

        // 4) declare overloading of operator + to add 2 objects of Money
        public static Money operator +(Money money1, Money money2)
        {
            //return money1.CurrencyTypes == money2.CurrencyTypes ? new Money(money1.Amount + money2.Amount, money1.CurrencyTypes) : null;
            return new Money(money1.Amount + money2.Amount);
        }

        // 5) declare overloading of operator -- to decrease object of Money by 1
        public static Money operator --(Money money1)
        {
            return new Money(--money1.Amount);
        }

        // 6) declare overloading of operator * to increase object of Money 3 times

        public static Money operator *(Money money1, int count)
        {
            return new Money(money1.Amount * count);
        }

        // 7) declare overloading of operator > and < to compare 2 objects of Money
        public static bool operator >(Money money1, Money money2)
        {
            return money1.Amount > money2.Amount;
        }

        public static bool operator <(Money money1, Money money2)
        {
            return money1.Amount < money2.Amount;
        }

        // 8) declare overloading of operator true and false to check CurrencyType of object
        public static bool operator true(Money money)
        {
            return money.CurrencyTypes is CurrencyTypes.UAH || money.CurrencyTypes is CurrencyTypes.USD || money.CurrencyTypes is CurrencyTypes.EU;
        }
        public static bool operator false(Money money)
        {
            return money.CurrencyTypes != CurrencyTypes.UAH && money.CurrencyTypes != CurrencyTypes.USD && money.CurrencyTypes != CurrencyTypes.EU;
        }

        // 9) declare overloading of implicit/ explicit conversion  to convert Money to double, string and vice versa
        public static explicit operator Money(double money)
        {
            return new Money((decimal)money);
        }
        public static explicit operator double(Money money)
        {
            return (double)money.Amount;
        }
        public static implicit operator Money(string money)
        {
            return new Money(decimal.Parse(money));
        }

        public static explicit operator string(Money money)
        {
            return money.Amount.ToString();
        }


    }
}
