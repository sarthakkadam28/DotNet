// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using MYCONSOLEAPP;

 decimal IncomeTax=TaxManager.CalculateIncomeTax(150000);
decimal salesTax=TaxManager.CalculateSalesTax(2000);
decimal propertyTAX = TaxManager.CalculatePropertyTax(300000);

Console.WriteLine($"Income Tax: {IncomeTax}");
Console.WriteLine($"Sales Tax: {salesTax}");
Console.WriteLine($"Property Tax: {propertyTAX}");

