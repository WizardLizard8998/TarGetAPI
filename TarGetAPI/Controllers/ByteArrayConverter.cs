﻿using System.Text.Json;
using System;
using System.Text.Json.Serialization;

public class ByteArrayConverter : JsonConverter<byte[]>
{
    public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        short[] sByteArray = JsonSerializer.Deserialize<short[]>(ref reader);
       // byte[] sByteArray = JsonSerializer.Deserialize<byte[]>(ref reader);
        byte[] value = new byte[sByteArray.Length];

        for (int i = 0; i < sByteArray.Length; i++)
        {
            value[i] = (byte)sByteArray[i];
        }

        return value;
    }

    public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var val in value)
        {
            writer.WriteNumberValue(val);
        }

        writer.WriteEndArray();
    }
}



/*
 
  public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        short[] sByteArray = JsonSerializer.Deserialize<short[]>(ref reader);
        byte[] value = new byte[sByteArray.Length];
        for (int i = 0; i < sByteArray.Length; i++)
        {
            value[i] = (byte)sByteArray[i];
        }

        return value;
    }

    public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var val in value)
        {
            writer.WriteNumberValue(val);
        }

        writer.WriteEndArray();
    }
 
 */