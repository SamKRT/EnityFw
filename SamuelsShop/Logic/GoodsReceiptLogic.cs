using FirstContactWithEFCore.Data;
using SamuelsShop.Models;
using System;
using System.Linq;

namespace SamuelsShop.Logic
{
    class GoodsReceiptLogic
    {
       
        private GoodsReceiptDraft goodsReceiptDraft { get; set; }
        private double? productTargetTemperature { get; set; }
        private double? measuredTemperature { get; set; }


        public GoodsReceiptLogic()
        {
            
            
        }

        private void ShowOverview(GoodsReceipt goodsReceipt)
        {
            Console.WriteLine();
            Console.WriteLine("---------- Overview ----------");
            Console.WriteLine($"ProductID:          {goodsReceipt.ProductID}");
            Console.WriteLine($"BestBefore:         {goodsReceipt.BestBefore}");
            Console.WriteLine($"ChargeID:           {goodsReceipt.ChargeID}");
            Console.WriteLine($"GoodsDamaged:       {goodsReceipt.GoodsDamaged}");
            Console.WriteLine($"GoodsIncomplete:    {goodsReceipt.GoodsIncomplete}");
            Console.WriteLine($"Quantity:           {goodsReceipt.Quantity}");
            if(measuredTemperature.HasValue)
                Console.WriteLine($"MeasuredTemperature:{goodsReceipt.MeasuredTemperature}");
            else
                Console.WriteLine($"MeasuredTemperature:Not needed");
            Console.WriteLine($"AcceptanceDay:      {goodsReceipt.AcceptanceDay}");
            Console.WriteLine();
        }
        
        private double? GetTargetTemperature(int productID)
        {
            using (SamuelsShopContext context = new SamuelsShopContext())
            {
                var targetTemperature = from product in context.Products
                                        where product.ProductID == productID
                                        select product.TargetTemperature;

                return targetTemperature.FirstOrDefault();
            }
        }

        private void ChangeEntryTask(GoodsReceipt goodsReceipt)
        {
            while (true)
            {
                Console.WriteLine("What do you want to change?");
                Console.WriteLine("[1]  Product ID");
                Console.WriteLine("[2]  Quantity");
                Console.WriteLine("[3]  Best befor");
                Console.WriteLine("[4]  Charge ID");
                Console.WriteLine("[5]  Goods incomplete");
                Console.WriteLine("[6]  Goods damaged");
                Console.WriteLine("[7]  Measured temprature");
                Console.WriteLine("[8]  Finish");

                int inputSelection = EnterPromptWithMessage<int>("");

                if (inputSelection == 1)
                {
                    while (true)
                    {
                        int productID = EnterPromptWithMessage<int>("Enter new product ID:");
                        if (CheckProductID(productID))
                        {
                            goodsReceipt.ProductID = productID;
                            productTargetTemperature = GetTargetTemperature(productID);
                            if (productTargetTemperature.HasValue)
                            {
                                goodsReceipt.MeasuredTemperature = measuredTemperature = EnterPromptWithMessage<double>("Now you must measured the temperture again. Enter measured temperature:");
                            }
                            else
                                goodsReceipt.MeasuredTemperature = measuredTemperature = null;
                            break;
                        }
                        Console.WriteLine("This product ID is not available!");
                    }
                }
                else if (inputSelection == 2)
                    goodsReceipt.Quantity = EnterPromptWithMessage<int>("Enter new quantity:");
                else if (inputSelection == 3)
                    goodsReceipt.BestBefore = EnterPromptWithMessage<DateTime>("Enter new best befor:");
                else if (inputSelection == 4)
                    goodsReceipt.ChargeID = EnterPromptWithMessage<int>("Enter new charge ID:");
                else if (inputSelection == 5)
                    goodsReceipt.GoodsIncomplete = EnterPromptWithMessage<bool>("Enter new goods incomplete:");
                else if (inputSelection == 6)
                    goodsReceipt.GoodsDamaged = EnterPromptWithMessage<bool>("Enter new goods demaged:");
                else if (inputSelection == 7)
                {
                    if(productTargetTemperature.HasValue)
                        goodsReceipt.MeasuredTemperature = measuredTemperature = EnterPromptWithMessage<double>("Enter new measured temperature:");
                    else
                        Console.WriteLine("This product does not need to be measured.");
                }
                else if (inputSelection == 8)
                    break;
            }
        }
        
        private bool CheckProductID(int ID)
        {
            using(SamuelsShopContext context = new SamuelsShopContext())
            {
                var products = from product in context.Products
                                where product.ProductID == ID
                                select product.ProductID;

                if (products.Count() == 1)
                    return true;
                else
                    return false;
            }
        }

        private Nullable<T> EnterPromptWithMessageNullable<T>(string message) where T : struct
        {
            T inputConverted;
            while (true)
            {
                Console.WriteLine(message + "(with enter \"skip\", you skip this input)");
                try
                {
                    string inputString = Console.ReadLine();
                    if (inputString.ToLower() == "skip")
                        return null;
                    
                    inputConverted = (T)Convert.ChangeType(inputString, typeof(T));
                    return inputConverted;
                }
                catch
                {
                    Console.WriteLine("Wrong entry");
                }
            }
        }

        private T EnterPromptWithMessage<T>(string message)
        {
            T inputConverted;
            while (true)
            {
                
                try
                {
                    Console.WriteLine(message);
                    inputConverted = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    return inputConverted;
                }
                catch
                {
                    Console.WriteLine("Wrong entry");
                }
            }
        }



        public bool Selection(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine().ToLower();
                Console.WriteLine();
                if (input == "yes")
                    return true;
                else if(input == "no")
                    return false;
                Console.WriteLine();
            }
            
        }
        
        public GoodsReceipt CreateTask()
        {
            int productID = EnterPromptWithMessage<int>("Enter product ID:");

            if (CheckProductID(productID) == true)
            {
                int quanitity = EnterPromptWithMessage<int>("Enter quantity:");
                DateTime bestbefor = EnterPromptWithMessage<DateTime>("Enter bestbefore:");
                int chargeID = EnterPromptWithMessage<int>("Enter charge ID:");
                bool goodsDemaged = EnterPromptWithMessage<bool>("Goods demaged?");
                bool goodsIncomplete = EnterPromptWithMessage<bool>("Goods incomplete?");
                
                productTargetTemperature = GetTargetTemperature(productID);
                if (productTargetTemperature.HasValue)
                    measuredTemperature = EnterPromptWithMessage<double>("Enter the measured temperature:(with \",\"");
                else
                    measuredTemperature = null;

                return new GoodsReceipt()
                {
                    AcceptanceDay = DateTime.Now,
                    BestBefore = bestbefor,
                    ChargeID = chargeID,
                    GoodsDamaged = goodsDemaged,
                    GoodsIncomplete = goodsIncomplete,
                    Quantity = quanitity,
                    ProductID = productID,
                    MeasuredTemperature = measuredTemperature
                };

                


                
            }
            return null;
        }

        public void SaveDataToDatabase(bool taskOrDraft, GoodsReceipt goodsReceipt)        //Task is true //Draft is false
        {
            if (taskOrDraft)
            {
                ShowOverview(goodsReceipt);
                if (Selection("Do you want to save? (yes/no)"))
                {
                    using (SamuelsShopContext context = new SamuelsShopContext())
                    {
                        context.GoodsReceipts.Add(goodsReceipt);


                        if (productTargetTemperature.HasValue && Math.Abs(productTargetTemperature.Value - measuredTemperature.Value) > 0.2)
                        {
                            context.SaveChanges();
                            Console.WriteLine("Goods receipt task created successfully.");
                            Console.WriteLine($">> The temperature isn't in the tolerance range {productTargetTemperature}° ± 0,2°!");
                            Console.WriteLine(">> Don't use the goods for your shop. Throw the goods in the trash.");
                            Console.WriteLine(">> The quantity were not added to your stock");

                        }
                        else
                        {
                            var productStock = from p in context.Products
                                               where p.ProductID == goodsReceipt.ProductID
                                               select p;

                            productStock.First().Stock += goodsReceipt.Quantity;
                            context.SaveChanges();
                            Console.WriteLine("Goods receipt task created successfully.");
                            Console.WriteLine(">> The quantity were added to your stock.");
                        }
                    }

                }
                else
                {
                    if (Selection("Do you want to change something? (yes/no) (no: Discard all.)" +""))
                    {
                        ChangeEntryTask(goodsReceipt);
                        SaveDataToDatabase(taskOrDraft, goodsReceipt);
                    }
                }
            }
        }
        
        
        
        
        
        
        
        //Not used
        private void CreateDraft()
        {
            int? productID = EnterPromptWithMessageNullable<int>("Enter product ID:");
            int? quanitity = EnterPromptWithMessageNullable<int>("Enter quantity:");
            DateTime? bestbefor = EnterPromptWithMessageNullable<DateTime>("Enter bestbefore:");
            int? chargeID = EnterPromptWithMessageNullable<int>("Enter charge ID:");
            bool? goodsDemaged = EnterPromptWithMessageNullable<bool>("Goods demaged?");
            bool? goodsIncomplete = EnterPromptWithMessageNullable<bool>("Goods incomplete?");
            double? measuredTemperature = EnterPromptWithMessageNullable<double>("Enter the measured temperature:(with \",\"");

            string draftName = EnterPromptWithMessage<string>("Enter the draftname:");

            goodsReceiptDraft = new GoodsReceiptDraft()
            {
                AcceptanceDay = DateTime.Now,
                BestBefore = bestbefor,
                ChargeID = chargeID,
                GoodsDamaged = goodsDemaged,
                GoodsIncomplete = goodsIncomplete,
                Quantity = quanitity,
                ProductID = productID,
                MeasuredTemperature = measuredTemperature,
                DraftName = draftName
            };
        }
    }
}
