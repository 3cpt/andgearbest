# AndGearbest

[![Build Status](https://travis-ci.org/oandreeeee/andgearbest.svg?branch=master)](https://travis-ci.org/oandreeeee/andgearbest)
[![NuGet version](https://badge.fury.io/nu/andgearbest.svg)](https://badge.fury.io/nu/andgearbest)

A simple C# Wrapper for the Gearbest Associate Program api.

## Installation

Install AndGearbest through NuGet:
```
PM> Install-Package AndGearbest
```

## Usage

### Main API
First of all, in order to use the api you need to be a member of the Gearbest Affiliate program and susbcribed to the API in order to get an ApiKey and ApiSecret.

Create an instance of GearbestApi (implements IGearbestApi interface)
```c#
var api = AndGearbestApi.GetGearbestApi(<API_KEY>, <API_SECRET>, <LKID(optional)>);
```

To get a coupons:
```c#
  var coupons = api.GetCouponsAsync().Result;
```

Note: if any lkid as send, it uses a default lkid.

## Contribution

Any pull request or suggestion is welcome.

## Libraries used

This wrapper uses [Newtonsoft.Json](https://www.nuget.org/packages/newtonsoft.json/).

## License

Is under the [MIT license](LICENSE.md).

## Disclaimer

Andgearbest isn't an official version or isn't build with relation to Gearbest registered trademarks. This is a self and indepent project. Used only the information and documention provided by Gearbest Associate Program

## Thanks
To [Ben Fradet](https://github.com/BenFradet)
