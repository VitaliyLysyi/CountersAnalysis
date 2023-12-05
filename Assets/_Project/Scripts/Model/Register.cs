using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountersAnalysis
{
    public class Register
    {
        private RegisterData _registerData;

        public void load()
        {
            string path = Constants.DEFAULT_REGISTER_FILE_PATH;
            _registerData = DataHandler.loadXML<RegisterData>(path);

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
        }

        public void add(RegisterElementData registerElementData)
        {
            registerElementData.registerID = ++_registerData.lastID;
            _registerData.registerElements.Add(registerElementData);
            save();
        }

        public void save()
        {
            DataHandler.saveXML(_registerData, Constants.DEFAULT_REGISTER_FILE_PATH);
        }

        //public void removeRegistred(int registredID)
        //{
        //    RegisterElementData data = _registerData.FirstOrDefault(element => element.registerID == registredID);
        //    DataHandler.deleteFile(data.path);
        //    _registerData.Remove(data);
        //    saveRegister();
        //}

        //public RegisterElementData getRegistredElement(int id)
        //{
        //    return _registerData.FirstOrDefault(element => element.registerID == id);
        //}

        //public RegisterElementData getRegistredElement(string name)
        //{
        //    return _registerData.FirstOrDefault(element => element.name == name);
        //}

        //public void saveRegister()
        //{
        //    RegisterData packageRegisterData = new RegisterData();
        //    string path = Constants.DEFAULT_REGISTER_FILE_PATH;
        //    DataHandler.saveXML<RegisterData>(packageRegisterData, path);
        //}

        //public List<RegisterElementData> registerData => _registerData;

        //public RegisterElementData lastRegistredData => _registerData.LastOrDefault();
    }
}