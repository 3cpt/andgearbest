# AndGearbest

[![Build Status](https://travis-ci.org/andxpto/andgearbest.svg?branch=master)](https://travis-ci.org/oandreeeee/andgearbest)
[![NuGet version](https://badge.fury.io/nu/andgearbest.svg)](https://badge.fury.io/nu/andgearbest)
[![Build Status](https://andcorreia.visualstudio.com/andgearbest/_apis/build/status/andxpto.andgearbest?branchName=master)](https://andcorreia.visualstudio.com/andgearbest/_build/latest?definitionId=8&branchName=master)
[![Build Status](https://andcorreia.visualstudio.com/andgearbest/_apis/build/status/andxpto.andgearbest?branchName=dev)](https://andcorreia.visualstudio.com/andgearbest/_build/latest?definitionId=8&branchName=dev)

dotnet API Client for the Gearbest Associate Program api

## Installation

Install AndGearbest through NuGet:
```
PM> Install-Package AndGearbest
```

## Usage

**Note:** Check [dev branch](https://github.com/andxpto/andgearbest/tree/dev) for next features or improves

### Main API
First of all, in order to use the api you need to be a member of the Gearbest Affiliate program and susbcribed to the API in order to get an ApiKey and ApiSecret.

Create an instance of GearbestApi (implements IGearbestApi interface)
```c#
var api = AndGearbestApi.GetGearbestApi(<API_KEY>, <API_SECRET>, <LKID(optional)>);
```

To get a coupons:
```c#
  var coupons = await api.GetCouponsAsync();
```

Note: if any lkid as send, it uses a default lkid.

## Contribution

Any pull request or suggestion is welcome.

## Libraries used

This wrapper uses [Newtonsoft.Json](https://www.nuget.org/packages/newtonsoft.json/).

## License

[MIT license](LICENSE).

## Disclaimer

Andgearbest isn't an official version or isn't build with relation to Gearbest registered trademarks. This is an indepent project. This project uses the information and documention provided by Gearbest Associate/Affiliate Program.

## Thanks
To [Ben Fradet](https://github.com/BenFradet)
