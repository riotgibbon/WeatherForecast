using System.Threading.Tasks;
using WeatherForecast.Core;

namespace WeatherForecast.MVVMCore.Models
{
    public class MockWeatherUndergroundSource : WeatherUndergroundSource
    {
        #region WeatherUndergroundSource Members


        public Task<string> GetJsonAsync()
        {
            return Task.Run(() => GetJson());
        }

        public string GetJson()
        {
            return @"
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
		'date':'12:00 AM GMT',
		'forecastday': [
		{
		'period':0,
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'title':'Wednesday',
		'fcttext':'Overcast with a chance of rain in the morning, then mostly cloudy. High of 54F. Winds from the SE at 5 to 10 mph. Chance of rain 20%.',
		'fcttext_metric':'Overcast with a chance of rain in the morning, then mostly cloudy. High of 12C. Winds from the SE at 5 to 15 km/h.',
		'pop':'20'
		}
		,
		{
		'period':1,
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'title':'Wednesday Night',
		'fcttext':'Overcast in the evening, then partly cloudy. Fog overnight. Low of 39F. Winds less than 5 mph.',
		'fcttext_metric':'Overcast in the evening, then partly cloudy. Fog overnight. Low of 4C. Winds less than 5 km/h.',
		'pop':'0'
		}
		,
		{
		'period':2,
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'title':'Thursday',
		'fcttext':'Overcast in the morning, then partly cloudy. High of 52F. Winds from the ENE at 5 to 10 mph.',
		'fcttext_metric':'Overcast in the morning, then partly cloudy. High of 11C. Winds from the ENE at 5 to 15 km/h.',
		'pop':'0'
		}
		,
		{
		'period':3,
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'title':'Thursday Night',
		'fcttext':'Overcast in the evening, then clear. Low of 37F. Winds less than 5 mph.',
		'fcttext_metric':'Overcast in the evening, then clear. Low of 3C. Winds less than 5 km/h.',
		'pop':'0'
		}
		,
		{
		'period':4,
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'title':'Friday',
		'fcttext':'Clear. High of 54F. Winds from the SSE at 5 to 10 mph.',
		'fcttext_metric':'Clear. High of 12C. Winds from the SSE at 10 to 15 km/h.',
		'pop':'0'
		}
		,
		{
		'period':5,
		'icon':'cloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/cloudy.gif',
		'title':'Friday Night',
		'fcttext':'Mostly cloudy in the evening, then overcast with a chance of rain. Fog overnight. Low of 48F. Winds from the South at 5 to 10 mph. Chance of rain 20%.',
		'fcttext_metric':'Mostly cloudy in the evening, then overcast with a chance of rain. Fog overnight. Low of 9C. Winds from the South at 10 to 15 km/h.',
		'pop':'20'
		}
		,
		{
		'period':6,
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'title':'Saturday',
		'fcttext':'Overcast with a chance of rain in the morning, then mostly cloudy. High of 54F. Winds from the West at 5 to 15 mph. Chance of rain 20%.',
		'fcttext_metric':'Overcast with a chance of rain in the morning, then mostly cloudy. High of 12C. Breezy. Winds from the West at 10 to 20 km/h.',
		'pop':'20'
		}
		,
		{
		'period':7,
		'icon':'mostlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/mostlycloudy.gif',
		'title':'Saturday Night',
		'fcttext':'Overcast. Low of 39F. Winds from the West at 5 to 10 mph.',
		'fcttext_metric':'Overcast. Low of 4C. Winds from the West at 10 to 15 km/h.',
		'pop':'0'
		}
		]
		},
		'simpleforecast': {
		'forecastday': [
		{'date':{
	'epoch':'1352926800',
	'pretty':'9:00 PM GMT on November 14, 2012',
	'day':14,
	'month':11,
	'year':2012,
	'yday':318,
	'hour':21,
	'min':'00',
	'sec':0,
	'isdst':'0',
	'monthname':'November',
	'weekday_short':'Wed',
	'weekday':'Wednesday',
	'ampm':'PM',
	'tz_short':'GMT',
	'tz_long':'Europe/London'
},
		'period':1,
		'high': {
		'fahrenheit':'54',
		'celsius':'12'
		},
		'low': {
		'fahrenheit':'39',
		'celsius':'4'
		},
		'conditions':'Chance of Rain',
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'skyicon':'partlycloudy',
		'pop':20,
		'qpf_allday': {
		'in': 0.00,
		'mm': 0.0
		},
		'qpf_day': {
		'in': 0.00,
		'mm': 0.0
		},
		'qpf_night': {
		'in': 0.00,
		'mm': 0.0
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
		'mph': 6,
		'kph': 10,
		'dir': 'SE',
		'degrees': 134
		},
		'avewind': {
		'mph': 5,
		'kph': 8,
		'dir': 'East',
		'degrees': 101
		},
		'avehumidity': 90,
		'maxhumidity': 98,
		'minhumidity': 81
		}
		,
		{'date':{
	'epoch':'1353013200',
	'pretty':'9:00 PM GMT on November 15, 2012',
	'day':15,
	'month':11,
	'year':2012,
	'yday':319,
	'hour':21,
	'min':'00',
	'sec':0,
	'isdst':'0',
	'monthname':'November',
	'weekday_short':'Thu',
	'weekday':'Thursday',
	'ampm':'PM',
	'tz_short':'GMT',
	'tz_long':'Europe/London'
},
		'period':2,
		'high': {
		'fahrenheit':'52',
		'celsius':'11'
		},
		'low': {
		'fahrenheit':'37',
		'celsius':'3'
		},
		'conditions':'Partly Cloudy',
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'skyicon':'mostlysunny',
		'pop':0,
		'qpf_allday': {
		'in': 0.00,
		'mm': 0.0
		},
		'qpf_day': {
		'in': 0.00,
		'mm': 0.0
		},
		'qpf_night': {
		'in': 0.00,
		'mm': 0.0
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
		'mph': 6,
		'kph': 10,
		'dir': 'ENE',
		'degrees': 62
		},
		'avewind': {
		'mph': 4,
		'kph': 6,
		'dir': 'East',
		'degrees': 84
		},
		'avehumidity': 87,
		'maxhumidity': 97,
		'minhumidity': 83
		}
		,
		{'date':{
	'epoch':'1353099600',
	'pretty':'9:00 PM GMT on November 16, 2012',
	'day':16,
	'month':11,
	'year':2012,
	'yday':320,
	'hour':21,
	'min':'00',
	'sec':0,
	'isdst':'0',
	'monthname':'November',
	'weekday_short':'Fri',
	'weekday':'Friday',
	'ampm':'PM',
	'tz_short':'GMT',
	'tz_long':'Europe/London'
},
		'period':3,
		'high': {
		'fahrenheit':'54',
		'celsius':'12'
		},
		'low': {
		'fahrenheit':'48',
		'celsius':'9'
		},
		'conditions':'Partly Cloudy',
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'skyicon':'mostlysunny',
		'pop':0,
		'qpf_allday': {
		'in': 0.00,
		'mm': 0.0
		},
		'qpf_day': {
		'in': 0.00,
		'mm': 0.0
		},
		'qpf_night': {
		'in': 0.03,
		'mm': 0.8
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
		'mph': 8,
		'kph': 13,
		'dir': 'South',
		'degrees': 173
		},
		'avewind': {
		'mph': 7,
		'kph': 11,
		'dir': 'South',
		'degrees': 170
		},
		'avehumidity': 74,
		'maxhumidity': 85,
		'minhumidity': 70
		}
		,
		{'date':{
	'epoch':'1353186000',
	'pretty':'9:00 PM GMT on November 17, 2012',
	'day':17,
	'month':11,
	'year':2012,
	'yday':321,
	'hour':21,
	'min':'00',
	'sec':0,
	'isdst':'0',
	'monthname':'November',
	'weekday_short':'Sat',
	'weekday':'Saturday',
	'ampm':'PM',
	'tz_short':'GMT',
	'tz_long':'Europe/London'
},
		'period':4,
		'high': {
		'fahrenheit':'54',
		'celsius':'12'
		},
		'low': {
		'fahrenheit':'39',
		'celsius':'4'
		},
		'conditions':'Chance of Rain',
		'icon':'partlycloudy',
		'icon_url':'http://icons-ak.wxug.com/i/c/k/partlycloudy.gif',
		'skyicon':'partlycloudy',
		'pop':20,
		'qpf_allday': {
		'in': 0.06,
		'mm': 1.5
		},
		'qpf_day': {
		'in': 0.03,
		'mm': 0.8
		},
		'qpf_night': {
		'in': 0.00,
		'mm': 0.0
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
		'dir': 'SSW',
		'degrees': 203
		},
		'avewind': {
		'mph': 8,
		'kph': 13,
		'dir': 'West',
		'degrees': 280
		},
		'avehumidity': 74,
		'maxhumidity': 100,
		'minhumidity': 57
		}
		]
		}
	}
}"; 
        }

        #endregion


    }
}
