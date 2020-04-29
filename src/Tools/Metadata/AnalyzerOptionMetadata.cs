﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Roslynator.Metadata
{
    public class AnalyzerOptionMetadata
    {
        public AnalyzerOptionMetadata(
            string identifier,
            AnalyzerOptionKind kind,
            string title,
            string messageFormat,
            bool isEnabledByDefault,
            bool supportsFadeOut,
            string summary,
            IEnumerable<SampleMetadata> samples,
            bool isObsolete)
        {
            Identifier = identifier;
            Kind = kind;
            Title = title;
            MessageFormat = messageFormat;
            IsEnabledByDefault = isEnabledByDefault;
            SupportsFadeOut = supportsFadeOut;
            Summary = summary;
            Samples = new ReadOnlyCollection<SampleMetadata>(samples?.ToArray() ?? Array.Empty<SampleMetadata>());
            IsObsolete = isObsolete;
        }

        public AnalyzerMetadata CreateAnalyzerMetadata(AnalyzerMetadata parent)
        {
            return new AnalyzerMetadata(
                id: parent.Id + "_" + Identifier,
                identifier: parent.Identifier + "_" + Identifier,
                title: Title,
                messageFormat: MessageFormat,
                category: "AnalyzerOption",
                defaultSeverity: parent.DefaultSeverity,
                isEnabledByDefault: IsEnabledByDefault,
                isObsolete: parent.IsEnabledByDefault || IsObsolete,
                supportsFadeOut: false,
                supportsFadeOutAnalyzer: false,
                minLanguageVersion: parent.MinLanguageVersion,
                summary: Summary,
                remarks: null,
                samples: Samples,
                links: null,
                options: null);
        }

        public string Identifier { get; }

        public AnalyzerOptionKind Kind { get; }

        public string Title { get; }

        public string MessageFormat { get; }

        public bool IsEnabledByDefault { get; }

        public bool SupportsFadeOut { get; }

        public string Summary { get; }

        public IReadOnlyList<SampleMetadata> Samples { get; }

        public bool IsObsolete { get; }
    }
}