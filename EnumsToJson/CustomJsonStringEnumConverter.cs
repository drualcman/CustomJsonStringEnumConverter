﻿using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnumsToJson;

public class CustomJsonStringEnumConverter : JsonConverterFactory
{
    private readonly JsonStringEnumConverter baseConverter;

    public CustomJsonStringEnumConverter(JsonNamingPolicy namingPolicy = null, bool allowIntegerValues = true)
    {
        baseConverter = new JsonStringEnumConverter(namingPolicy, allowIntegerValues);
    }

    public override bool CanConvert(Type typeToConvert) => baseConverter.CanConvert(typeToConvert);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return baseConverter.CreateConverter(typeToConvert, options);
    }
}
