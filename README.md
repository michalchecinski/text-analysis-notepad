# Text analysis notepad
Simple WPF app that uses Azure Text Analisis (Cognitive Services) to analyze text input.
It was made for GirlzCamp 2018 demo. How to connect simple WPF apps with powerful services.

## App.settings
In order to use this app you must provide key to Azure Text Analysis service. 

You must add Connection string named *AzureCognitiveServices* in App.config file.

For example:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
<!-- other config here -->
  <connectionStrings>
    <add name="AzureCognitiveServices"

         connectionString="paste-your-key-here"/>

  </connectionStrings>
</configuration>
```