﻿#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json.Converters;

namespace Newtonsoft.Json.Tests.Converters
{
  public class JavaScriptDateTimeConverterTests : TestFixtureBase
  {
    [Test]
    public void SerializeDateTime()
    {
      JavaScriptDateTimeConverter converter = new JavaScriptDateTimeConverter();

      DateTime d = new DateTime(2000, 12, 15, 22, 11, 3, 55, DateTimeKind.Utc);
      string result;

      result = JavaScriptConvert.SerializeObject(d, converter);
      Assert.AreEqual("new Date(976918263055)", result);
    }

    [Test]
    public void SerializeDateTimeOffset()
    {
      JavaScriptDateTimeConverter converter = new JavaScriptDateTimeConverter();

      DateTimeOffset now = new DateTimeOffset(2000, 12, 15, 22, 11, 3, 55, TimeSpan.Zero);
      string result;

      result = JavaScriptConvert.SerializeObject(now, converter);
      Assert.AreEqual("new Date(976918263055)", result);
    }

    [Test]
    public void DeserializeDateTime()
    {
      JavaScriptDateTimeConverter converter = new JavaScriptDateTimeConverter();

      DateTime result = JavaScriptConvert.DeserializeObject<DateTime>("new Date(976918263055)", converter);
      Assert.AreEqual(new DateTime(2000, 12, 15, 22, 11, 3, 55, DateTimeKind.Utc), result);
    }

    [Test]
    public void DeserializeDateTimeOffset()
    {
      JavaScriptDateTimeConverter converter = new JavaScriptDateTimeConverter();
      DateTimeOffset start = new DateTimeOffset(2000, 12, 15, 22, 11, 3, 55, TimeSpan.Zero);

      string json = JavaScriptConvert.SerializeObject(start, converter);

      DateTimeOffset result = JavaScriptConvert.DeserializeObject<DateTimeOffset>(json, converter);
      Assert.AreEqual(new DateTimeOffset(2000, 12, 15, 22, 11, 3, 55, TimeSpan.Zero), result);
    }
  }
}