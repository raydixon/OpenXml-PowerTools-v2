﻿using System;

namespace OpenXmlPowerTools.Documents
{
    /// <summary>
    /// WmlSource builder
    /// </summary>
    public class WmlSourceBuilder
    {
        private WmlDocument _document { get; set; } = null;
        private int _start { get; set; } = 0;
        private int _count { get; set; } = int.MaxValue;
        private bool _keepHeadersAndFooters { get; set; } = true;
        private bool _keepSections { get; set; } = true;
        private string _insertId { get; set; } = null;

        public WmlSourceBuilder() { }
        public WmlSourceBuilder(string fileName) : this(new WmlDocument(fileName)) { }

        public WmlSourceBuilder(WmlDocument document)
        {
            _document = document;
        }

        /// <summary>
        /// Set file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public WmlSourceBuilder FileName(string fileName)
        {
            _document = new WmlDocument(fileName);
            return this;
        }

        /// <summary>
        /// Set OpenXml Wordprocessing document 
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public WmlSourceBuilder Document(WmlDocument document)
        {
            _document = document;
            return this;
        }

        /// <summary>
        /// Set starting body part
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        public WmlSourceBuilder Start(int start)
        {
            _start = start;
            return this;
        }

        /// <summary>
        /// Set number of body parts to include
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public WmlSourceBuilder Count(int count)
        {
            _count = count;
            return this;
        }

        /// <summary>
        /// Set keep headers and footers
        /// </summary>
        /// <param name="keepHeadersAndFooters"></param>
        /// <returns></returns>
        public WmlSourceBuilder KeepHeadersAndFooters(bool keepHeadersAndFooters = true)
        {
            _keepHeadersAndFooters = keepHeadersAndFooters;
            return this;
        }

        /// <summary>
        /// Set keep sections
        /// </summary>
        /// <param name="keepSections"></param>
        /// <returns></returns>
        public WmlSourceBuilder KeepSections(bool keepSections = true)
        {
            _keepSections = keepSections;
            return this;
        }

        public WmlSourceBuilder Defaults()
        {
            _start = 0;
            _count = int.MaxValue;
            _keepSections = true;
            _keepHeadersAndFooters = true;
            _insertId = null;
            return this;
        }

        /// <summary>
        /// Build given file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public WmlSource Build(string filePath) => Build(new WmlDocument(filePath));

        /// <summary>
        /// Build given wml document
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public WmlSource Build(WmlDocument document)
        {
            _document = document;
            return Build();
        }

        /// <summary>
        /// Processes and saves document
        /// </summary>
        public WmlSource Build()
        {
            if (_document == null) throw new ArgumentException("Document cannot be null.");

            return new WmlSource()
            {
                WmlDocument = _document,
                Start = _start,
                Count = _count,
                KeepHeadersAndFooters = _keepHeadersAndFooters,
                KeepSections = _keepSections,
                InsertId = _insertId,
            };
        }
    }
}