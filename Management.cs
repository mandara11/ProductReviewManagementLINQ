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
    }
}
