using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using AG.Common;

namespace AG.TweeterDAL
{
    public class FileDataSource : IDataSource
    {
        private ILogger Logger;
        private string FileName;
        private bool IsValid;

        public FileDataSource(string fileName,ILogger logger)
        {
            Logger = logger;

            if (string.IsNullOrEmpty(fileName))
            {
                Logger.LogError("File name may not be empty");                
            }                        
            else
            {
                FileName = fileName;                
            }
        }

        public IDictionary<int,string> GetData()
        {
            try
            {                
                var resultDictionary = new Dictionary<int, string>();
                var fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                int lineCounter = 0;
                using (var streamReader = new StreamReader(fileStream, Encoding.ASCII))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (!resultDictionary.TryAdd(lineCounter, line))
                        {
                            Logger.LogError("Error adding line to dictionary");
                        }
                        else
                        {
                            lineCounter++;
                        }
                    }
                }
                return resultDictionary;
            }
            catch (FileNotFoundException fx)
            {
                Logger.LogError($"File not found exception : {fx.FileName}",fx);
            }
            catch(Exception ex)
            {
                Logger.LogError($"Error occurred reading file '{FileName}'",ex);
            }

            return null;                                       
        }
        
    }
}
