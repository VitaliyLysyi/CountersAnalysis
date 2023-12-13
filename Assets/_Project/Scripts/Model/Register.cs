using System;
using System.Collections.Generic;
using System.Linq;

namespace CountersAnalysis
{
    public class Register
    {
        private List<RegisterElementData> _data;
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
                _data = new List<RegisterElementData>();
                return;
            }

            _data = _data.Where(data => FileHandler.fileExist(data.path)).ToList();
        }

        public void add(IRegistrable registarble)
        {
            RegisterElementData registrableData = registarble.getRegistrableData();
            registrableData.registerID = ++_lastID;
            dataExistCheck(registrableData.path);
            registarble.updateRegistrableData(registrableData);
            _data.Add(registrableData);
        }

        private void dataExistCheck(string path)
        {
            RegisterElementData existingData = getElement(path);
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
            RegisterElementData data = getElement(id);
            if (data.Equals(default))
                return;

            _data.Remove(data);
        }

        public RegisterElementData getElement(string path)
        {
            return _data.FirstOrDefault(data => data.path == path);
        }

        public RegisterElementData getElement(int id)
        {
            return _data.FirstOrDefault(data => data.registerID == id);
        }

        public List<RegisterElementData> getAllByType(RegistredDataType dataType)
        {
            return _data.Where(data => data.elementType == dataType.ToString()).ToList();
        }

        public RegisterElementData getLast() => _data.LastOrDefault();
    }
}