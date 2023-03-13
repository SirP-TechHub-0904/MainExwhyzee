﻿using Amazon.S3;
using MainExwhyzee.Domain.Data;
using MainExwhyzee.Domain.Dtos.AwsDtos;
using MainExwhyzee.Domain.Services.AWS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NirsalProject.Pages.Shared.ViewComponents
{
    public class HomeSearchViewComponent : ViewComponent
    {
        private readonly UserManager<MainExwhyzee.Domain.Models.Profile> _userManager;
        //private readonly IAmazonS3 _s3Client;
        private readonly ApplicationDbContext _context;
        private readonly IStorageService _storageService;
        private readonly IConfiguration _config;


        public HomeSearchViewComponent(
            UserManager<MainExwhyzee.Domain.Models.Profile> userManager, ApplicationDbContext context/*, IAmazonS3 s3Client*/, IStorageService storageService, IConfiguration config)
        {
            _userManager = userManager;
            _context = context;
            //_s3Client = s3Client;
            _storageService = storageService;
            _config = config;
        }

        public string UserInfo { get; set; }

        public async Task<IViewComponentResult> InvokeAsync(string key)
        {

            //string bucketName = "lojourxyz";
            //var bucketExists = await _s3Client.DoesS3BucketExistAsync(bucketName);
            ////if (!bucketExists) return NotFound($"Bucket {bucketName} does not exist.");
            //var s3Object = await _s3Client.GetObjectAsync(bucketName, key);
            ////return File(s3Object.ResponseStream, s3Object.Headers.ContentType);



            ////var doctype = await _context.ApplicantDocuments.Include(x => x.DocumentType).FirstOrDefaultAsync(x => x.Id == id);
            ////if(doctype == null)
            ////{
            ////    TempData["e"] = "Not Processed";
            ////}

            var s3Obj = new MainExwhyzee.Domain.Dtos.AwsDtos.S3GetObjectDto()
            {
                Bucket = "lojourxyz",
                Key = key
            };

            var cred = new AwsCredentials()
            {
                AccessKey = _config["AwsConfiguration:AWSAccessKey"],
                SecretKey = _config["AwsConfiguration:AWSSecretKey"]
            };

            var result = await _storageService.DownloadFileAsync(s3Obj.Key, s3Obj.Bucket, cred);
            // 
            
            ViewBag.outcome = result;
            return View();
        }
    }
}
