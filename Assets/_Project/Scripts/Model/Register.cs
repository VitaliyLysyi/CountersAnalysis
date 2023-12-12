using System;
using System.Collections.Generic;
using System.Linq;

namespace CountersAnalysis
{
    public class Register
    {
        private RegisterData _registerData;

        public void load()
        {
            string path = Constants.DEFAULT_REGISTER_FILE_PATH;
            _registerData = FileHandler.readXML<RegisterData>(path);

            bool registerDataNotExist = _registerData.Equals(default(RegisterData));
            if (registerDataNotExist)
            {
                create();
            }
        }

        private void create()
        {
            _registerData = new RegisterData();
            _registerData.registerElements = new List<RegisterElementData>();
            save();
        }

        public void add(RegisterElementData data)
        {
            //if (nameSimilarityCheck(data))
            //{
            //    throw new Exception("Елемент з такою назвою вже завантажено в програму");
            //}

            data.registerID = ++_registerData.lastID;
            _registerData.registerElements.Add(data);
            save();
        }

        private bool nameSimilarityCheck(RegisterElementData data)
        {
            return _registerData.registerElements.Any(registredData => registredData.name == data.name);
        }

        public void save()
        {
            FileHandler.writeXML(_registerData, Constants.DEFAULT_REGISTER_FILE_PATH);
        }

        public void remove(RegisterElementData data) => remove(data.registerID);

        public void remove(int id)
        {
            RegisterElementData data = find(id);
            if (data.Equals(default))
            {
                return;
            }

            _registerData.registerElements.Remove(data);
            save();
        }

        public RegisterElementData find(RegisterElementData data) => find(data.registerID);

        public RegisterElementData find(int id)
        {
            return _registerData.registerElements.FirstOrDefault(data => data.registerID == id);
        }

        public List<RegisterElementData> getAll() => _registerData.registerElements;

        public RegisterElementData getLast() => _registerData.registerElements.LastOrDefault();
    }
}