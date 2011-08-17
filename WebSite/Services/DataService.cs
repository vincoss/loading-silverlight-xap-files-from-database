using System;
using System.IO;
using System.Linq;
using WebSite.Services.Data;
using WebSite.Models;


namespace WebSite
{
    public interface IDataService
    {
        StreamModel GetStream(string fileName);
        void Save(bool overwrite, string fileName, string contentType, Stream inputStream);
    }

    public class DataService : IDataService
    {
        public void Save(bool overwrite, string fileName, string contentType, Stream inputStream)
        {
            using (SilverlightDataEntities context = new SilverlightDataEntities())
            {
                BinaryStream entity = context.BinaryStreams.SingleOrDefault(x => x.FileName == fileName);
                if (entity == null)
                {
                    entity = new BinaryStream();
                    entity.FileName = fileName;
                    entity.ContentType = contentType;
                    entity.Size = inputStream.Length;
                    entity.BlobData = GetByteFromStream(inputStream);

                    context.BinaryStreams.AddObject(entity);
                }
                context.SaveChanges();
            }
        }

        public StreamModel GetStream(string fileName)
        {
            StreamModel model = null;
            using (SilverlightDataEntities context = new SilverlightDataEntities())
            {
                var entity = context.BinaryStreams.SingleOrDefault(x => x.FileName == fileName);
                if (entity != null)
                {
                    model = new StreamModel();
                    model.ContentType = entity.ContentType;
                    model.Data = entity.BlobData;
                }
            }
            return model;
        }

        #region Private methods

        private byte[] GetByteFromStream(Stream stream)
        {
            int bufferLength = (int)stream.Length;
            byte[] buffer = new byte[bufferLength];
            StreamReader sr = new StreamReader(stream);
            stream.Read(buffer, 0, bufferLength);
            return buffer;
        } 
        #endregion
    }
}