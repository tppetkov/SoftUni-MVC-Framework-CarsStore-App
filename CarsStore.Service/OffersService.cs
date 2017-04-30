namespace CarsStore.Service
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;

    using AutoMapper;

    using CarsStore.Models.BindingModels;
    using CarsStore.Models.BindingModels.Blog;

    using Models.EntityModels;
    using Models.ViewModels.Adverts;

    public class OffersService:Service
    {
        public DetailsOfferVm GetDetails(int id)
        {
            CarOffer advert = this.Context.CarsAdvertisements.Find(id);
            if (advert == null)
            {
                return null;
            }

            DetailsOfferVm vm = Mapper.Map<CarOffer, DetailsOfferVm>(advert);

            return vm;
        }

        public void AddNewOffer(AddOfferBm bind, HttpPostedFileBase file, string username)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == username);
            CarOffer model = Mapper.Map<AddOfferBm, CarOffer>(bind);
            model.Brand = bind.Brand;
            model.Model = bind.Model;
            model.OriginDate = bind.OriginDate;
            model.Description = bind.Description;
            model.Price = bind.Price;
            model.Image = this.GetImageFromBind(file);
            model.Seller = currentUser;
            this.Context.CarsAdvertisements.Add(model);
            this.Context.SaveChanges();
        }

        private byte[] GetImageFromBind(HttpPostedFileBase bindImage)
        {
            if (bindImage != null)
            {
                var fileName = Path.GetFileName(bindImage.FileName);
                byte[] bytes = new byte[bindImage.ContentLength];
                int bytesToRead = (int)bindImage.ContentLength;
                int bytesRead = 0;
                while (bytesToRead > 0)
                {
                    int n = bindImage.InputStream.Read(bytes, bytesRead, bytesToRead);
                    if (n == 0) break;
                    bytesRead += n;
                    bytesToRead -= n;
                }

                return bytes;
            }

            return null;
        }

        public CarOffer GetAttractionImage(int id)
        {
            var offer = this.Context.CarsAdvertisements.Find(id);

            return offer;
        }
    }  
}