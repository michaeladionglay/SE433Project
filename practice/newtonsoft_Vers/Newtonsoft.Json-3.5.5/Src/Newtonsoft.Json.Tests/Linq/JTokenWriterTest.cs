#region License
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
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Newtonsoft.Json.Tests.Linq
{
  public class JTokenWriterTest : TestFixtureBase
  {
    [Test]
    public void ValueFormatting()
    {
      JToken root;
      using (JTokenWriter jsonWriter = new JTokenWriter())
      {
        jsonWriter.WriteStartArray();
        jsonWriter.WriteValue('@');
        jsonWriter.WriteValue("\r\n\t\f\b?{\\r\\n\"\'");
        jsonWriter.WriteValue(true);
        jsonWriter.WriteValue(10);
        jsonWriter.WriteValue(10.99);
        jsonWriter.WriteValue(0.99);
        jsonWriter.WriteValue(0.000000000000000001d);
        jsonWriter.WriteValue(0.000000000000000001m);
        jsonWriter.WriteValue((string)null);
        jsonWriter.WriteValue("This is a string.");
        jsonWriter.WriteNull();
        jsonWriter.WriteUndefined();
        jsonWriter.WriteEndArray();

        root = jsonWriter.Token;
      }

      Assert.IsInstanceOfType(typeof(JArray), root);
      Assert.AreEqual(12, root.Children().Count());
      Assert.AreEqual("@", (string)root[0]);
      Assert.AreEqual("\r\n\t\f\b?{\\r\\n\"\'", (string)root[1]);
      Assert.AreEqual(true, (bool)root[2]);
      Assert.AreEqual(10, (int)root[3]);
      Assert.AreEqual(10.99, (double)root[4]);
      Assert.AreEqual(0.99, (double)root[5]);
      Assert.AreEqual(0.000000000000000001d, (double)root[6]);
      Assert.AreEqual(0.000000000000000001m, (decimal)root[7]);
      Assert.AreEqual(string.Empty, (string)root[8]);
      Assert.AreEqual("This is a string.", (string)root[9]);
      Assert.AreEqual(null, ((JValue)root[10]).Value);
    }

    [Test]
    public void State()
    {
      using (JsonWriter jsonWriter = new JTokenWriter())
      {
        Assert.AreEqual(WriteState.Start, jsonWriter.WriteState);

        jsonWriter.WriteStartObject();
        Assert.AreEqual(WriteState.Object, jsonWriter.WriteState);

        jsonWriter.WritePropertyName("CPU");
        Assert.AreEqual(WriteState.Property, jsonWriter.WriteState);

        jsonWriter.WriteValue("Intel");
        Assert.AreEqual(WriteState.Object, jsonWriter.WriteState);

        jsonWriter.WritePropertyName("Drives");
        Assert.AreEqual(WriteState.Property, jsonWriter.WriteState);

        jsonWriter.WriteStartArray();
        Assert.AreEqual(WriteState.Array, jsonWriter.WriteState);

        jsonWriter.WriteValue("DVD read/writer");
        Assert.AreEqual(WriteState.Array, jsonWriter.WriteState);

        jsonWriter.WriteEnd();
        Assert.AreEqual(WriteState.Object, jsonWriter.WriteState);

        jsonWriter.WriteEndObject();
        Assert.AreEqual(WriteState.Start, jsonWriter.WriteState);
      }
    }
  }
}