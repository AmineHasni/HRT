# HRT
High Frequency Trading Project - Interactive Brokers (IB) Platform

# Overview

This project integrates with the Interactive Brokers (IB) API to facilitate trading automation, market data retrieval, and order execution.

#Prerequisites

Ensure you have the following installed:

.NET 6.0+

Interactive Brokers Trader Workstation (TWS) or IB Gateway

IB API (Interactive Brokers API)

# Installation

Clone the Repository

Install Dependencies

Configure IB TWS or IB Gateway

Enable API Access: Go to Edit > Global Configuration > API > Settings

Check Enable ActiveX and Socket Clients

Set Socket Port (default: 7497 for paper trading, 7496 for live trading)

Allow connections from 127.0.0.1

Uncheck Read-Only API if order placement is needed

Environment Variables
Create an appsettings.json file in the root directory and configure it:

{ "IBSettings": { "Host": "127.0.0.1", "Port": 7497, "ClientId": 1 } }

Running the Project

Check Connection to IB API

# Contact

For support, reach out to amine.hasni.dev@gmail.com or create an issue in the repository.
