using System;
using System.Collections.Generic;

namespace Comindware.Platform.WebApi.Contracts
{
     [Serializable]
    public class Localized<T>
    {
        public T En { get; set; }
        public T De { get; set; }
        public T Ru { get; set; }

        private static readonly HashSet<string> LanguagesDe = new HashSet<string> { "de", "de-DE", "de-AT", "de-LI", "de-LU", "de-CH" };
        private static readonly HashSet<string> LanguagesRu = new HashSet<string> { "ru", "ru-RU", "be", "be-BY", "uk", "uk-UA" };
        public T Value
        {
            //ToDo: Optimize this
            get
            {
                var c = System.Threading.Thread.CurrentThread.CurrentCulture;
                if (LanguagesRu.Contains(c.Name))
                    return Ru;

                if (LanguagesDe.Contains(c.Name))
                    return De;

                return En;
            }
        }

        public Localized() { }

        public Localized(T value)
        {
            En = De = Ru = value;
        }

        public Localized(T en, T de, T ru)
        {
            En = en;
            De = de;
            Ru = ru;
        }
    }
}