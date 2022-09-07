﻿using System;
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
    }
}
