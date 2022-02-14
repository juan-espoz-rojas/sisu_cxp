using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Text;

namespace Presentacion.Navigation
{
    public class ParameterCollection
    {
        #region Private Members

        private IDictionary<string, string> parameterDictionary;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Creates and initializes a new instance of a ParameterCollection object. 
        /// </summary>
        public ParameterCollection()
        {
            parameterDictionary = new Dictionary<string, string>();
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Adds an element with the provided key and value to the IDictionary object. 
        /// </summary>
        /// <param name="name">parameter</param>
        /// <param name="value">value</param>
        public void Add(string name, string value)
        {
            this.parameterDictionary.Remove(name);
            this.parameterDictionary.Add(name, value);
        }


        public void Remove(string Key)
        {
            this.parameterDictionary.Remove(Key);
        }

        /// <summary>
        /// Adds an element with the provided key and value to the IDictionary object. 
        /// </summary>
        /// <param name="nameValuePair">Parameter Name - Parameter Value pair.</param>
        public void Add(KeyValuePair<string, string> nameValuePair)
        {
            this.parameterDictionary.Add(nameValuePair);
        }

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public string this[string key]
        {
            get
            {
                return this.parameterDictionary.ContainsKey(key) ? this.parameterDictionary[key] : null;
            }
        }


        public KeyValuePair<string, string> this[int Index]
        {
            get
            {
                int i = 0;
                foreach (string aKey in this.parameterDictionary.Keys)
                {
                    if (i == Index)
                    {
                        return new KeyValuePair<string, string>(aKey, this.parameterDictionary[aKey]);
                    }
                    else i++;
                }
                return new KeyValuePair<string, string>(string.Empty, string.Empty);
            }
        }

        /// <summary>
        /// Devuelve la representación string de este objeto, de la forma:
        /// [key1=value1, key2=value2, ...keyN=valueN]
        /// </summary>
        /// <returns>Representación string de este objeto.</returns>
        public override string ToString()
        {
            StringBuilder paramsStr = new StringBuilder("[");
            if (this.parameterDictionary != null)
            {
                foreach (string aKey in this.parameterDictionary.Keys)
                    paramsStr.Append(aKey).Append("=").Append(this.parameterDictionary[aKey]).Append(", ");
            }
            if (paramsStr.Length > 1)
                paramsStr.Remove(paramsStr.Length - 2, 2);
            paramsStr.Append("]");
            return paramsStr.ToString();
        }

        #endregion Public Methods

        #region GetEnumerator

        /// <summary>
        /// Returns an IDictionaryEnumerator object for the IDictionary object.
        /// </summary>
        /// <returns>IEnumerator element</returns>
        public IEnumerator GetEnumerator()
        {
            return parameterDictionary.GetEnumerator();
        }

        #endregion GetEnumerator
    }
}