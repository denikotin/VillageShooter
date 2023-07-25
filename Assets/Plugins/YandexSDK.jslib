mergeInto(LibraryManager.library, {

ShowSimpleAdv: function()
{
  ShowInterstishialAdv();
},

ShowRewardAdv: function()
{
  ShowRewardedAdv();
},

GetCurrentLanguage: function()
{
    var lang = window.ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
},

GetCurrentDomain: function()
{
    var domain = window.ysdk.environment.i18n.tld;
    var bufferSize =lengthBytesUTF8(domain) +1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(domain, buffer, bufferSize);
    return buffer;
},


SaveGame: function(string)
{
  Save(UTF8ToString(string));
},

LoadGame: function()
{
  var saves = Load();
  if(saves == null)
  {
    return saves;
  }else
  {
    var bufferSize = lengthBytesUTF8(saves) +1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(saves, buffer, bufferSize);
    return buffer;
  }

},

Rate: function()
{
  RateGame();
},

});