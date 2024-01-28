using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Blog List");
                workSheet.Cell(1, 1).Value = "Blog ID"; // first row first column .. 
                workSheet.Cell(1, 2).Value = "Blog Name"; // first row second column ..

                int blogRowCount = 2; // i write 2 because first row we will have titles (Id and name) 
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.ID; // blorRowCount is row , 1 is column ..
                    workSheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "Worksheet1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>
            {
                new BlogModel {ID=1, BlogName = "Introduction to C# programming"},
                new BlogModel {ID=2, BlogName = "Introduction to SQL"},
                new BlogModel {ID=3, BlogName = "Introduction to React.JS"}
            };
            return blogModels;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Blog List");
                workSheet.Cell(1, 1).Value = "Blog ID"; // first row first column .. 
                workSheet.Cell(1, 2).Value = "Blog Name"; // first row second column ..

                int blogRowCount = 2; // i write 2 because first row we will have titles (Id and name) 
                foreach (var item in BlogTitleList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.ID; // blorRowCount is row , 1 is column ..
                    workSheet.Cell(blogRowCount, 2).Value = item.Name;
                    blogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "Worksheet1.xlsx");
                }
            }
        }

        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bM = new List<BlogModel2>();
            using (var c = new MyContext())
            {
                bM = c.Blogs.Select(x => new BlogModel2
                { ID = x.ID, Name = x.Title }).ToList();
            }
            return bM;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
