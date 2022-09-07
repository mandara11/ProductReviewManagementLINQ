using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class Management
    {
        public readonly DataTable dataTable = new DataTable();

        // UC1:- Product Review Management
        public void IterateProductReview(List<ProductReview> productReviewList)
        {
            foreach (ProductReview list in productReviewList) //print list item
            {
                Console.WriteLine("ProductId:-" + list.ProductId + "  " + "UserId:-" + list.UserId + "  " + "Rating:-" + list.Rating
                    + "  " + "Review:-" + list.Review + "  " + "IsLike:-" + list.IsLike); //Print data
            }
        }

        // UC2:Retrieve top 3 records from the list who’s rating is high using LINQ. 
        public static void RetrieveTop3records(List<ProductReview> productReviewList)
        {
            //Query syntax for LINQ
            var result = (from products in productReviewList
                          orderby products.Rating descending
                          select products).Take(3);
            foreach (var elements in result)
            {
                Console.WriteLine($"ProductId:- {elements.ProductId} UserId:- {elements.UserId} Rating:- {elements.Rating} Review:- {elements.Review} isLike:- {elements.IsLike}");
            }
        }

        /*UC3:- Retrieve all record from the list who’s rating are greater than 3 and 
                productID is 1 or 4 or 9 using LINQ.*/
        
        public static void RetrieveRecordsWithGreaterThanThreeRating(List<ProductReview> productReviewList)
        {           //Query syntax for LINQ 
            var RecordedData = (from productReviews in productReviewList
                                where (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9)
                                && productReviews.Rating > 3
                                select productReviews);
            Console.WriteLine("\nProducts with Rating Greater than 3 and productID = 1 or 4 or 9 are:- ");
            foreach (var List in RecordedData)
            {
                Console.WriteLine($"ProductId:- {List.ProductId}   || UserId:- {List.UserId}   || Rating:- {List.Rating}   || Review:- {List.Review}   ||   IsLike:- {List.IsLike}"); //Print data
            }
        }

        /* UC4:- Retrieve count of review present for each productID.
               - Use groupBy LINQ Operator.*/
        public static void RetrieveCountOfReviewForEachProductId(List<ProductReview> productReviewList)
        {
            var RecordedData = (productReviewList.GroupBy(p => p.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() }));
            Console.WriteLine("\n Count group by ProductId");
            foreach (var List in RecordedData)
            {
                Console.WriteLine($"ProductId:- {List.ProductId}   || Count :- {List.Count}"); //Print data
            }
        }

        /* UC5:- Retrieve only productId and review from the list for all Records. 
               - Use select LINQ Operator.*/
        public static void RetrieveProductIDAndReviewOfAllRecords(List<ProductReview> productReviewList)
        {
            try
            {
                //Query syntax for LINQ 
                var RecordedData = (from products in productReviewList
                                    select new { ProductId = products.ProductId, Review = products.Review });
                Console.WriteLine("Retrieving Product and Review from list:-");
                foreach (var productReview in RecordedData) //traversing each items
                {
                    Console.WriteLine($"ProductID:-  {productReview.ProductId}  \t Review:-  {productReview.Review}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC6:- Skip top 5 records from the list using LINQ and display other Records.
        public static void SkipTopFiveRecords(List<ProductReview> productReviewList)
        {
            try
            {
                var RecordedData = (from products in productReviewList
                                    select products).Skip(5);
                Console.WriteLine("\n Skiping the Top five records and Display others ");
                foreach (var productReview in RecordedData) //traversing each items
                {
                    Console.WriteLine($"ProductId:- {productReview.ProductId}\tUserId:- {productReview.UserId}\tRating:- {productReview.Rating}\t  Review:- {productReview.Review}  \t    isLike:- {productReview.IsLike}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //*UC7:- Retrieve only productId and review from the list for all records using LINQ select operator.
        public static void RetrieveProductIDAndReviewUsingLambdaSyntax(List<ProductReview> productReviewList)
        {
            try
            {                // Query syntax for LINQ 
                var RecordedData = productReviewList.Select(reviews => new { ProductId = reviews.ProductId, Review = reviews.Review });
                Console.WriteLine("\nRetrieving Product and Review from list");
                foreach (var productReview in RecordedData) //traversing each items
                {
                    Console.WriteLine($"ProductId:- {productReview.ProductId}\tReview:- {productReview.Review}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*UC8:- Create DataTable using C# and Add ProductID, UserID, Rating, Review and isLike fields in that.
              - Add 25 default values in datatable list which we have UC 8 created Class Program.*/
        public static void CreateDataTable() //create method
        {
            try
            {
                DataTable table = new DataTable(); //create table and create object
                table.Columns.Add("ProductId", typeof(Int32)); // add Columns in table
                table.Columns.Add("UserId", typeof(Int32)); // add Columns in table
                table.Columns.Add("Rating", typeof(double)); // add Columns in table
                table.Columns.Add("Review", typeof(string)); // add Columns in table
                table.Columns.Add("isLike", typeof(bool)); // add Columns in table


                table.Rows.Add(1, 1, 4, "Average", true); //Adding Data
                table.Rows.Add(1, 2, 2, "Bad", false); //Adding Data
                table.Rows.Add(3, 3, 4, "Nice", true); //Adding Data
                table.Rows.Add(4, 4, 5, "Good", false); //Adding Data
                table.Rows.Add(5, 5, 6, "Excelent", false); //Adding Data
                table.Rows.Add(6, 10, 4, "Nice", true); //Adding Data
                table.Rows.Add(7, 6, 3, "Average", true); //Adding Data
                table.Rows.Add(8, 5, 2, "Bad", true); //Adding Data
                table.Rows.Add(9, 10, 5, "Good", true); //Adding Data
                table.Rows.Add(10, 41, 6, "Excelent", false); //Adding Data
                table.Rows.Add(11, 5, 4, "Nice", false); //Adding Data
                table.Rows.Add(12, 4, 1, "Very Bad", true); //Adding Data
                table.Rows.Add(13, 48, 0, "Excelent", false); //Adding Data
                table.Rows.Add(14, 41, 3, "Average", true); //Adding Data
                table.Rows.Add(15, 51, 4, "Nice", true); //Adding Data
                table.Rows.Add(16, 8, 1, "Very Bad", false); //Adding Data
                table.Rows.Add(17, 18, 6, "Excelent", true); //Adding Data
                table.Rows.Add(18, 9, 5, "Good", true); //Adding Data
                table.Rows.Add(19, 10, 4, "Nice", false); //Adding Data
                table.Rows.Add(20, 7, 3, "Average", true); //Adding Data
                table.Rows.Add(21, 6, 2, "Bad", true); //Adding Data
                table.Rows.Add(22, 5, 1, "Very Bad", false); //Adding Data
                table.Rows.Add(23, 10, 5, "Good", false); //Adding Data
                table.Rows.Add(24, 8, 2, "Bad", true); //Adding Date
                table.Rows.Add(22, 12, 3, "Average", false); //Adding Data

                Console.WriteLine("DataTable Records");
                foreach (var list in table.AsEnumerable())
                {
                    Console.WriteLine($"ProductId:- {list.Field<int>("ProductId")}    UserId:- {list.Field<int>("UserId")}\tRating:- {list.Field<double>("Rating")}\tReview:- {list.Field<string>("Review")} \tisLike:- {list.Field<bool>("isLike")}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // UC9:Retrieve all the records from the datatable variable who’s isLike value is true using LINQ
        public static DataTable table = new DataTable(); //create table and create object
        public static void RetrieveRecordWithTrueIsLike()
        {
            CreateDataTable(); //UC8
            var result = from product in table.AsEnumerable()
                         where product.Field<bool>("isLike") == true
                         select product;

            Console.WriteLine("\nRecords in table whose IsLike value is true");
            foreach (var list in result) //Printing data
            {
                Console.WriteLine("ProductId:-" + list.Field<int>("ProductId") + "\t" + "UserId:- " + list.Field<int>("UserId") + "\t" +
                    "Rating:-" + list.Field<double>("Rating") + "\t" + "Review:-" + list.Field<string>("Review") + "\t" + "isLike:-" + list.Field<bool>("isLike"));
            }
        }
    }
}
