# Seq.App.aspsms
[![Build Status](https://travis-ci.org/Hinni/Seq.App.aspsms.svg?branch=master)](https://travis-ci.org/Hinni/Seq.App.aspsms)
[![GitHub release](https://img.shields.io/github/release/Hinni/Seq.App.aspsms.svg)](https://github.com/Hinni/Seq.App.aspsms/releases)
[![NuGet](https://img.shields.io/nuget/v/Seq.App.aspsms.svg)](https://www.nuget.org/packages/Seq.App.aspsms/)

App for the Seq event server.
Allows you to notify a phone by SMS over aspsms.ch

## MessageText
The final message contains the DateTime, Level and RenderedMessage from given event.

## Caution
Be carefull with your event filter. Don't send too many messages - or your will be blocked by the service provider.
