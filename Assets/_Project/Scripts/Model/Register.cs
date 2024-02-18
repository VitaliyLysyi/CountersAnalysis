using System;
using System.Collections.Generic;
using System.Linq;

namespace CountersAnalysis
{
    public class Register
    {
        private List<RegistrableData> _data;
        private int _lastID;

        public void load()
        {
            string path = Constants.DEFAULT_REGISTER_FILE_PATH;
            RegisterData registerData = FileHandler.readXML<RegisterData>(path);
            _data = registerData.registerElements;
            _lastID = registerData.lastID;
            dataAvilabilityCheck();
        }

        private void dataAvilabilityCheck()
        {
            if (_data == null)
            {
                _data = new List<RegistrableData>();
                return;
            }

            _data = _data.Where(data => FileHandler.fileExist(data.path)).ToList();
        }

        public void add(IRegistrable registarble)
        {
            RegistrableData registrableData = registarble.getRegistrableData();
            registrableData.registerID = ++_lastID;
            dataExistCheck(registrableData.path);
            registarble.updateRegistrableData(registrableData);
            _data.Add(registrableData);
        }

        private void dataExistCheck(string path)
        {
            RegistrableData existingData = getData(path);
            if (existingData.path == path)
                throw new Exception("Файл з таким шляхом уже завантажувався в програму");
        }

        public void saveData()
        {
            RegisterData registerData = new RegisterData();
            registerData.lastID = _lastID;
            registerData.registerElements = _data;
            FileHandler.writeXML(registerData, Constants.DEFAULT_REGISTER_FILE_PATH);
        }

        public void remove(int id)
        {
            RegistrableData data = getData(id);
            if (data.Equals(default))
                return;

            _data.Remove(data);
        }

        public RegistrableData getData(string path)
        {
            return _data.FirstOrDefault(data => data.path == path);
        }

        public RegistrableData getData(int id)
        {
            return _data.FirstOrDefault(data => data.registerID == id);
        }

        public List<RegistrableData> getAllByType(RegistredDataType dataType)
        {
            return _data.Where(data => data.elementType == dataType.ToString()).ToList();
        }
    }
}