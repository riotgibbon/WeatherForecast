using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColdAlert.Tests
{
	public class MockWeatherSource: WeatherSource
	{

        #region WeatherSource Members

        public string GetWeatherData(string period)
        {
            return data;
        }

        #endregion

		private string data =
			@"
{
	'response': {
		'version': '0.1'
		,'termsofService': 'http://www.wunderground.com/weather/api/d/terms.html'
		,'features': {
		'forecast': 1
		}
	}
		,
	'forecast':{
		'txt_forecast': {
		'date':'1:00 PM BST',
		'forecastday': [
		{
		'period':0,
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'title':'Tuesday',
		'fcttext':'Overcast in the morning, then partly cloudy. High of 57F. Breezy. Winds from the WSW at 15 to 20 mph.',
		'fcttext_metric':'Overcast in the morning, then partly cloudy. High of 14C. Windy. Winds from the WSW at 25 to 35 km/h.',
		'pop':'0'
		}
		,
		{
		'period':1,
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'title':'Tuesday Night',
		'fcttext':'Clear in the evening, then overcast. Low of 45F. Winds from the SSE at 5 to 10 mph.',
		'fcttext_metric':'Clear in the evening, then overcast. Low of 7C. Breezy. Winds from the SSE at 10 to 20 km/h.',
		'pop':'0'
		}
		,
		{
		'period':2,
		'icon':'rain',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/rain.gif',
		'title':'Wednesday',
		'fcttext':'Overcast with rain, then a chance of rain in the afternoon. High of 59F. Breezy. Winds from the South at 10 to 20 mph. Chance of rain 80%.',
		'fcttext_metric':'Overcast with rain, then a chance of rain in the afternoon. High of 15C. Windy. Winds from the South at 20 to 30 km/h. Chance of rain 80%.',
		'pop':'80'
		}
		,
		{
		'period':3,
		'icon':'mostlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/mostlycloudy.gif',
		'title':'Wednesday Night',
		'fcttext':'Overcast in the evening, then mostly cloudy with a chance of rain. Low of 52F. Winds from the South at 5 to 10 mph. Chance of rain 20%.',
		'fcttext_metric':'Overcast in the evening, then mostly cloudy with a chance of rain. Low of 11C. Winds from the South at 10 to 15 km/h.',
		'pop':'20'
		}
		,
		{
		'period':4,
		'icon':'chancerain',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/chancerain.gif',
		'title':'Thursday',
		'fcttext':'Overcast with a chance of rain in the afternoon. High of 61F. Winds from the SSE at 10 to 15 mph. Chance of rain 40%.',
		'fcttext_metric':'Overcast with a chance of rain in the afternoon. High of 16C. Breezy. Winds from the SSE at 15 to 20 km/h. Chance of rain 40%.',
		'pop':'40'
		}
		,
		{
		'period':5,
		'icon':'chancerain',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/chancerain.gif',
		'title':'Thursday Night',
		'fcttext':'Overcast with a chance of rain. Fog overnight. Low of 50F. Winds from the SE at 10 to 15 mph. Chance of rain 40%.',
		'fcttext_metric':'Overcast with a chance of rain. Fog overnight. Low of 10C. Breezy. Winds from the SE at 15 to 25 km/h. Chance of rain 40%.',
		'pop':'40'
		}
		,
		{
		'period':6,
		'icon':'chancerain',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/chancerain.gif',
		'title':'Friday',
		'fcttext':'Overcast with a chance of rain. Fog early. High of 54F. Breezy. Winds from the South at 10 to 20 mph. Chance of rain 70% with rainfall amounts near 0.5 in. possible.',
		'fcttext_metric':'Overcast with a chance of rain. Fog early. High of 12C. Breezy. Winds from the South at 20 to 25 km/h. Chance of rain 70% with rainfall amounts near 12.7 mm possible.',
		'pop':'70'
		}
		,
		{
		'period':7,
		'icon':'chancerain',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/chancerain.gif',
		'title':'Friday Night',
		'fcttext':'Partly cloudy with a chance of rain. Fog overnight. Low of 46F. Winds from the SSW at 5 to 15 mph. Chance of rain 50% with rainfall amounts near 0.2 in. possible.',
		'fcttext_metric':'Partly cloudy with a chance of rain. Fog overnight. Low of 8C. Breezy. Winds from the SSW at 10 to 20 km/h. Chance of rain 50% with rainfall amounts near 5.1 mm possible.',
		'pop':'50'
		}
		]
		},
		'simpleforecast': {
		'forecastday': [
		{'date':{
	'epoch':'1350421200',
	'pretty':'10:00 PM BST on October 16, 2012',
	'day':16,
	'month':10,
	'year':2012,
	'yday':289,
	'hour':22,
	'min':'00',
	'sec':0,
	'isdst':'1',
	'monthname':'October',
	'weekday_short':'Tue',
	'weekday':'Tuesday',
	'ampm':'PM',
	'tz_short':'BST',
	'tz_long':'Europe/London'
},
		'period':1,
		'high': {
		'fahrenheit':'57',
		'celsius':'14'
		},
		'low': {
		'fahrenheit':'45',
		'celsius':'7'
		},
		'conditions':'Partly Cloudy',
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'skyicon':'partlycloudy',
		'pop':0,
		'qpf_allday': {
		'in': 0.03,
		'mm': 0.8
		},
		'qpf_day': {
		'in': 0.00,
		'mm': 0.0
		},
		'qpf_night': {
		'in': 0.05,
		'mm': 1.3
		},
		'snow_allday': {
		'in': 0,
		'cm': 0
		},
		'snow_day': {
		'in': 0,
		'cm': 0
		},
		'snow_night': {
		'in': 0,
		'cm': 0
		},
		'maxwind': {
		'mph': 20,
		'kph': 32,
		'dir': 'WSW',
		'degrees': 248
		},
		'avewind': {
		'mph': 11,
		'kph': 18,
		'dir': 'SW',
		'degrees': 232
		},
		'avehumidity': 74,
		'maxhumidity': 94,
		'minhumidity': 56
		}
		,
		{'date':{
	'epoch':'1350507600',
	'pretty':'10:00 PM BST on October 17, 2012',
	'day':17,
	'month':10,
	'year':2012,
	'yday':290,
	'hour':22,
	'min':'00',
	'sec':0,
	'isdst':'1',
	'monthname':'October',
	'weekday_short':'Wed',
	'weekday':'Wednesday',
	'ampm':'PM',
	'tz_short':'BST',
	'tz_long':'Europe/London'
},
		'period':2,
		'high': {
		'fahrenheit':'59',
		'celsius':'15'
		},
		'low': {
		'fahrenheit':'52',
		'celsius':'11'
		},
		'conditions':'Rain',
		'icon':'rain',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/rain.gif',
		'skyicon':'mostlycloudy',
		'pop':80,
		'qpf_allday': {
		'in': 0.11,
		'mm': 2.8
		},
		'qpf_day': {
		'in': 0.06,
		'mm': 1.5
		},
		'qpf_night': {
		'in': 0.02,
		'mm': 0.5
		},
		'snow_allday': {
		'in': 0,
		'cm': 0
		},
		'snow_day': {
		'in': 0,
		'cm': 0
		},
		'snow_night': {
		'in': 0,
		'cm': 0
		},
		'maxwind': {
		'mph': 16,
		'kph': 26,
		'dir': 'SSW',
		'degrees': 209
		},
		'avewind': {
		'mph': 11,
		'kph': 18,
		'dir': 'South',
		'degrees': 188
		},
		'avehumidity': 75,
		'maxhumidity': 99,
		'minhumidity': 64
		}
		,
		{'date':{
	'epoch':'1350594000',
	'pretty':'10:00 PM BST on October 18, 2012',
	'day':18,
	'month':10,
	'year':2012,
	'yday':291,
	'hour':22,
	'min':'00',
	'sec':0,
	'isdst':'1',
	'monthname':'October',
	'weekday_short':'Thu',
	'weekday':'Thursday',
	'ampm':'PM',
	'tz_short':'BST',
	'tz_long':'Europe/London'
},
		'period':3,
		'high': {
		'fahrenheit':'61',
		'celsius':'16'
		},
		'low': {
		'fahrenheit':'50',
		'celsius':'10'
		},
		'conditions':'Chance of Rain',
		'icon':'chancerain',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/chancerain.gif',
		'skyicon':'cloudy',
		'pop':40,
		'qpf_allday': {
		'in': 0.17,
		'mm': 4.3
		},
		'qpf_day': {
		'in': 0.06,
		'mm': 1.5
		},
		'qpf_night': {
		'in': 0.14,
		'mm': 3.6
		},
		'snow_allday': {
		'in': 0,
		'cm': 0
		},
		'snow_day': {
		'in': 0,
		'cm': 0
		},
		'snow_night': {
		'in': 0,
		'cm': 0
		},
		'maxwind': {
		'mph': 12,
		'kph': 19,
		'dir': 'South',
		'degrees': 175
		},
		'avewind': {
		'mph': 9,
		'kph': 14,
		'dir': 'SE',
		'degrees': 133
		},
		'avehumidity': 96,
		'maxhumidity': 100,
		'minhumidity': 83
		}
		,
		{'date':{
	'epoch':'1350680400',
	'pretty':'10:00 PM BST on October 19, 2012',
	'day':19,
	'month':10,
	'year':2012,
	'yday':292,
	'hour':22,
	'min':'00',
	'sec':0,
	'isdst':'1',
	'monthname':'October',
	'weekday_short':'Fri',
	'weekday':'Friday',
	'ampm':'PM',
	'tz_short':'BST',
	'tz_long':'Europe/London'
},
		'period':4,
		'high': {
		'fahrenheit':'54',
		'celsius':'12'
		},
		'low': {
		'fahrenheit':'46',
		'celsius':'8'
		},
		'conditions':'Chance of Rain',
		'icon':'chancerain',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/chancerain.gif',
		'skyicon':'cloudy',
		'pop':70,
		'qpf_allday': {
		'in': 0.74,
		'mm': 18.8
		},
		'qpf_day': {
		'in': 0.50,
		'mm': 12.7
		},
		'qpf_night': {
		'in': 0.20,
		'mm': 5.1
		},
		'snow_allday': {
		'in': 0,
		'cm': 0
		},
		'snow_day': {
		'in': 0,
		'cm': 0
		},
		'snow_night': {
		'in': 0,
		'cm': 0
		},
		'maxwind': {
		'mph': 15,
		'kph': 24,
		'dir': 'SSE',
		'degrees': 150
		},
		'avewind': {
		'mph': 9,
		'kph': 14,
		'dir': 'SW',
		'degrees': 220
		},
		'avehumidity': 96,
		'maxhumidity': 100,
		'minhumidity': 94
		}
		]
		}
	}
}'";

       
    }
}
