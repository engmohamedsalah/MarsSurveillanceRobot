using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Application.Exceptions;
using Application.Helpers;
using Application.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Application.Parser
{
    public class JsonParser
    {
        public static InputRequestJson ParseJsonFromFilePath(string filePath)
        {
            FileHelper.checkFilePath(filePath);

            try
            {
                string text = File.ReadAllText(filePath);
                return ParseInputFromJsonFile(text);
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex.Message);
            }
        }

        public static InputRequestJson ParseInputFromJsonFile(string jsonfile)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<InputRequestJson>(jsonfile);
                return result;
            }
            catch
            {
                throw new InvalidFileContentException(jsonfile);
            }
        }

        public static string ConvertToJson(OutputResponseJson outputResponseJson)
        {
            try
            {
                return JsonConvert.SerializeObject(outputResponseJson, Formatting.Indented, new StringEnumConverter());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}