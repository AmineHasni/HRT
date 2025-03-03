using IBApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HFT
{
    public partial class Form1: Form
    {

        // This delegate enables asynchronous calls for setting
        // the text property on a ListBox control.
        delegate void SetTextCallback(string text);

        delegate void SetTextCallbackTickPrice(string _tickPrice);
        delegate void SetTextCallbackTickString(string _tickString);
        delegate void SetTextCallbackScanner(string strScanner);
        delegate void SetTextCallbackTickSize(int tickerId, int field, int size);
        delegate void SetCallbackHistoricalData(string strHistoricalData);
        int order_id = 0;
        int timer1_counter = 5;

        public void AddListBoxItem(string text)
        {
            // See if a new invocation is required form a different thread            
            if (this.lbData.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AddListBoxItem);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                // Add the text string to the list box
                this.lbData.Items.Add(text);
            }
        }

        // Create the ibClient object to represent the connection
        HFT.EWrapperImpl ibClient;
        public Form1()
        {
            InitializeComponent();

            // instantiate the ibClient
            ibClient = new HFT.EWrapperImpl();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Parameters to connect to TWS are:
            // host       - IP address or host name of the host running TWS
            // port       - listening port 7496 or 7497
            // clientId   - client application identifier can be any number
            ibClient.ClientSocket.eConnect("", 7497, 0);

            var reader = new EReader(ibClient.ClientSocket, ibClient.Signal);
            reader.Start();
            new Thread(() => {
                while (ibClient.ClientSocket.IsConnected())
                {
                    ibClient.Signal.waitForSignal();
                    reader.processMsgs();
                }
            })
            { IsBackground = true }.Start();
            // Wait until the connection is completed
            while (ibClient.NextOrderId <= 0) { }


            // Set up the form object in the EWrapper
            ibClient.myform = (Form1)Application.OpenForms[0];



            getData();
        }

        public void AddTextBoxItemTickPrice(string _tickPrice)
        {
            if (this.tbLast.InvokeRequired)
            {
                SetTextCallbackTickPrice d = new SetTextCallbackTickPrice(AddTextBoxItemTickPrice);
                try
                {
                    this.Invoke(d, new object[] { _tickPrice });
                }
                catch (Exception e)
                {
                    Console.WriteLine("This is from tickPrice", e);
                }
            }
            else
            {

                string[] tickerPrice = new string[] { _tickPrice };
                tickerPrice = _tickPrice.Split(',');

                if (Convert.ToInt32(tickerPrice[0]) == 1)
                {
                    if (Convert.ToInt32(tickerPrice[1]) == 4)// Delayed Last quote 68, if you want realtime use tickerPrice == 4
                    {
                        // Add the text string to the list box

                        this.tbLast.Text = tickerPrice[2];

                    }
                    else if (Convert.ToInt32(tickerPrice[1]) == 2)  // Delayed Ask quote 67, if you want realtime use tickerPrice == 2
                    {
                        // Add the text string to the list box

                        this.tbAsk.Text = tickerPrice[2];

                    }
                    else if (Convert.ToInt32(tickerPrice[1]) == 1)  // Delayed Bid quote 66, if you want realtime use tickerPrice == 1
                    {
                        // Add the text string to the list box

                        this.tbBid.Text = tickerPrice[2];

                    }
                }

                switch (Convert.ToInt32(tickerPrice[0]))
                {
                    case 0:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView1[2, 0].Value = tick_price.ToString();
                            break;
                        }
                        break;
                    case 1:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView1[2, 1].Value = tick_price.ToString();
                            break;
                        }

                        break;
                    case 2:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView1[2, 2].Value = tick_price.ToString();
                            break;
                        }
                        break;
                    case 3:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView1[2, 3].Value = tick_price.ToString();
                            break;
                        }
                        break;
                    case 4:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView1[2, 4].Value = tick_price.ToString();
                            break;
                        }
                        break;
                    case 5:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView1[2, 5].Value = tick_price.ToString();
                            break;
                        }
                        break;
                    case 6:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView1[2, 6].Value = tick_price.ToString();
                            break;
                        }
                        break;
                    case 7:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView1[2, 7].Value = tick_price.ToString();
                            break; ;
                        }
                        break;
                    case 8:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView1[2, 8].Value = tick_price.ToString();
                            break;
                        }
                        break;
                    case 9:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView1[2, 9].Value = tick_price.ToString();
                            break;
                        }
                        break;

                    case 10:
                        if (Convert.ToInt32(tickerPrice[1]) == 4) // last price = 4
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView2[1, 0].Value = tick_price.ToString();

                            if (dataGridView2[4, 0].Value != null)
                            {
                                double previous_close = Convert.ToDouble(dataGridView2[4, 0].Value);
                                double change = Math.Round(((tick_price - previous_close) / previous_close) * 100, 2);
                                dataGridView2[3, 0].Value = change;
                            }
                            break;
                        }
                        if (Convert.ToInt32(tickerPrice[1]) == 9) // Close previous day
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            dataGridView2[4, 0].Value = tick_price.ToString();
                        }
                        break;

                    case 11:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView2[1, 1].Value = tick_price.ToString();

                            if (dataGridView2[4, 1].Value != null)
                            {
                                double previous_close = Convert.ToDouble(dataGridView2[4, 1].Value);
                                double change = Math.Round(((tick_price - previous_close) / previous_close) * 100, 2);
                                dataGridView2[3, 1].Value = change;
                            }
                            break;
                        }
                        if (Convert.ToInt32(tickerPrice[1]) == 9)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            dataGridView2[4, 1].Value = tick_price.ToString();
                        }
                        break;

                    case 12:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView2[1, 2].Value = tick_price.ToString();

                            if (dataGridView2[4, 2].Value != null)
                            {
                                double previous_close = Convert.ToDouble(dataGridView2[4, 2].Value);
                                double change = Math.Round(((tick_price - previous_close) / previous_close) * 100, 2);
                                dataGridView2[3, 2].Value = change;
                            }
                            break;
                        }
                        if (Convert.ToInt32(tickerPrice[1]) == 9)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            dataGridView2[4, 2].Value = tick_price.ToString();
                        }
                        break;

                    case 13:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView2[1, 3].Value = tick_price.ToString();

                            if (dataGridView2[4, 3].Value != null)
                            {
                                double previous_close = Convert.ToDouble(dataGridView2[4, 3].Value);
                                double change = Math.Round(((tick_price - previous_close) / previous_close) * 100, 2);
                                dataGridView2[3, 3].Value = change;
                            }
                            break;
                        }
                        if (Convert.ToInt32(tickerPrice[1]) == 9)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            dataGridView2[4, 3].Value = tick_price.ToString();
                        }
                        break;

                    case 14:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView2[1, 4].Value = tick_price.ToString();

                            if (dataGridView2[4, 4].Value != null)
                            {
                                double previous_close = Convert.ToDouble(dataGridView2[4, 4].Value);
                                double change = Math.Round(((tick_price - previous_close) / previous_close) * 100, 2);
                                dataGridView2[3, 4].Value = change;
                            }
                            break;
                        }
                        if (Convert.ToInt32(tickerPrice[1]) == 9)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            dataGridView2[4, 4].Value = tick_price.ToString();
                        }
                        break;

                    case 15:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView2[1, 5].Value = tick_price.ToString();

                            if (dataGridView2[4, 5].Value != null)
                            {
                                double previous_close = Convert.ToDouble(dataGridView2[4, 5].Value);
                                double change = Math.Round(((tick_price - previous_close) / previous_close) * 100, 2);
                                dataGridView2[3, 5].Value = change;
                            }
                            break;
                        }
                        if (Convert.ToInt32(tickerPrice[1]) == 9)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            dataGridView2[4, 5].Value = tick_price.ToString();
                        }
                        break;

                    case 16:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView2[1, 6].Value = tick_price.ToString();

                            if (dataGridView2[4, 6].Value != null)
                            {
                                double previous_close = Convert.ToDouble(dataGridView2[4, 6].Value);
                                double change = Math.Round(((tick_price - previous_close) / previous_close) * 100, 2);
                                dataGridView2[3, 6].Value = change;
                            }
                            break;
                        }
                        if (Convert.ToInt32(tickerPrice[1]) == 9)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            dataGridView2[4, 6].Value = tick_price.ToString();
                        }
                        break;

                    case 17:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView2[1, 7].Value = tick_price.ToString();

                            if (dataGridView2[4, 7].Value != null)
                            {
                                double previous_close = Convert.ToDouble(dataGridView2[4, 7].Value);
                                double change = Math.Round(((tick_price - previous_close) / previous_close) * 100, 2);
                                dataGridView2[3, 7].Value = change;
                            }
                            break;
                        }
                        if (Convert.ToInt32(tickerPrice[1]) == 9)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            dataGridView2[4, 7].Value = tick_price.ToString();
                        }
                        break;

                    case 18:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView2[1, 8].Value = tick_price.ToString();

                            if (dataGridView2[4, 8].Value != null)
                            {
                                double previous_close = Convert.ToDouble(dataGridView2[4, 8].Value);
                                double change = Math.Round(((tick_price - previous_close) / previous_close) * 100, 2);
                                dataGridView2[3, 8].Value = change;
                            }
                            break;
                        }
                        if (Convert.ToInt32(tickerPrice[1]) == 9)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            dataGridView2[4, 8].Value = tick_price.ToString();
                        }
                        break;

                    case 19:
                        if (Convert.ToInt32(tickerPrice[1]) == 4)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            tick_price = Math.Round(tick_price, 2);
                            dataGridView2[1, 9].Value = tick_price.ToString();

                            if (dataGridView2[4, 9].Value != null)
                            {
                                double previous_close = Convert.ToDouble(dataGridView2[4, 9].Value);
                                double change = Math.Round(((tick_price - previous_close) / previous_close) * 100, 2);
                                dataGridView2[3, 9].Value = change;
                            }
                            break;
                        }
                        if (Convert.ToInt32(tickerPrice[1]) == 9)
                        {
                            double tick_price = Convert.ToDouble(tickerPrice[2]);
                            dataGridView2[4, 9].Value = tick_price.ToString();
                        }
                        break;
                }


            }

        }
        private void getData()
        {
            ibClient.ClientSocket.cancelMktData(1); // cancel market data

            // used to clear the contents of the listView
            listViewTns.Items.Clear();

            DateTime now = DateTime.Now;

            lbHistoricalData.Items.Clear(); // clears the historical data list box
            ibClient.ClientSocket.cancelHistoricalData(99);
            chart1.Series[0].Points.Clear(); // clears the chart 
            string strEndDate = now.ToString("yyyyMMdd 16:05:00");
            // Time duration
            String strDuration = "1 D";
            // Bar size
            String strBarSize = "5 mins";

            // Create a new contract to specify the security we are searching for
            IBApi.Contract contract = new IBApi.Contract();
            // Create a new TagValueList object (for API version 9.71 and later) 
            List<IBApi.TagValue> mktDataOptions = new List<IBApi.TagValue>();

            // Set the underlying stock symbol fromthe cbSymbol combobox            
            contract.Symbol = cbSymbol.Text;
            // Set the Security type to STK for a Stock
            contract.SecType = "STK";
            // Use "SMART" as the general exchange
            contract.Exchange = "SMART";
            // Set the primary exchange (sometimes called Listing exchange)
            // Use either NYSE or ISLAND
            contract.PrimaryExch = "ISLAND";
            // Set the currency to USD
            contract.Currency = "USD";

            // If using delayed market data subscription un-comment 
            // the line below to request delayed data
            ibClient.ClientSocket.reqMarketDataType(3);  // delayed data = 3 live = 1

            // Kick off the subscription for real-time data 
            ibClient.ClientSocket.reqMktData(1, contract, "233", false, false, mktDataOptions);

            //tickerId, identifier which will serve to identify the incoming data.
            //contract, Contract you are interested in.
            //endDateTime, end date and time (the empty string indicates current present moment).
            //durationString, The amount of time(or Valid Duration String units) to go back from the request's given end date and time.
            //barSizeSetting, The Valid Bar Sizes
            //whatToShow, The type of data to retrieve. "TRADES", "MIDPOINT"
            //useRTH, Whether(1) or not(0) to retrieve data generated only within Regular Trading Hours(RTH)
            // Link to requesting historical data https://interactivebrokers.github.io/tws-api/historical_bars.html
            ibClient.ClientSocket.reqHistoricalData(99, contract, "", strDuration, strBarSize, "TRADES", 1, 1, false, null);

            timer1.Start();
        }

        public void AddListViewItemTickString(string _tickString)
        {
            if (this.listViewTns.InvokeRequired)
            {
                try
                {
                    SetTextCallbackTickString d = new SetTextCallbackTickString(AddListViewItemTickString);
                    this.Invoke(d, new object[] { _tickString });
                }
                catch (Exception)
                {

                }
            }
            else
            {
                try
                {
                    // get the bid price from the textbox Bid
                    double theBid = Convert.ToDouble(tbBid.Text);
                    // gets the ask price from the textbox Ask
                    double theAsk = Convert.ToDouble(tbAsk.Text);

                    // Contains Last Price, Trade Size, Trade Time, Total Volume, VWAP, 
                    // single trade flag true, or false.
                    // 6 items all together
                    // example 701.28;1;1348075471534;67854;701.46918464;true
                    // extract each value from string and store it in a string list
                    string[] listTimeSales = _tickString.Split(';');

                    // get the first value form the list convert it to a double this value is the last price
                    double last_price = Convert.ToDouble(listTimeSales[0]);

                    int trade_size = Convert.ToInt32(listTimeSales[1]);

                    double trade_time = Convert.ToDouble(listTimeSales[2]);

                    // adds 2 zeros to the trade size
                    int share_size = trade_size * 100;

                    // formats a string to commas
                    string strShareSize = share_size.ToString("###,####,##0");

                    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    epoch = epoch.AddMilliseconds(trade_time);
                    // *************************************************
                    epoch = epoch.AddHours(-5);   //Daylight saving time use -4 Summer otherwise use -5 Winter

                    string strSaleTime = epoch.ToString("h:mm:ss:ff");

                    double myMeanPrice = ((theAsk - theBid) / 2);
                    double myMean = (theBid + myMeanPrice);

                    ListViewItem lx = new ListViewItem();

                    // string dt = String.Format("{0:hh:mm:ss}", dnt);

                    // if the last price is the same as the ask change the color to green
                    if (last_price == theAsk)
                    {
                        lx.ForeColor = Color.Green; // listview foreground color
                        lx.Text = (listTimeSales[0]); // last price
                        lx.SubItems.Add(strShareSize); // share size
                        lx.SubItems.Add(strSaleTime); // time
                        listViewTns.Items.Insert(0, lx); // use Insert instead of Add listView.Items.Add(li); 
                    }
                    // if the last price is the same as the bid change the color to red
                    else if (last_price == theBid)
                    {
                        lx.ForeColor = Color.Red;
                        lx.Text = (listTimeSales[0]);
                        lx.SubItems.Add(strShareSize);
                        lx.SubItems.Add(strSaleTime);
                        listViewTns.Items.Insert(0, lx);

                        lbData.Items.Insert(0, strSaleTime);
                    }
                    // if the last price in greater than the mean price and
                    // less than the ask price change the color to lime green
                    else if (last_price > myMean && last_price < theAsk)
                    {
                        lx.ForeColor = Color.Lime;
                        lx.Text = (listTimeSales[0]);
                        lx.SubItems.Add(strShareSize);
                        lx.SubItems.Add(strSaleTime);
                        listViewTns.Items.Insert(0, lx);

                        lbData.Items.Add(epoch);
                    }
                    else
                    {
                        lx.ForeColor = Color.DarkRed;
                        lx.Text = (listTimeSales[0]);
                        lx.SubItems.Add(strShareSize);
                        lx.SubItems.Add(strSaleTime);
                        listViewTns.Items.Insert(0, lx);
                    }
                }
                catch
                {

                }
            }
        }

        public void send_order(string side)
        {
            // Create a new contract to specify the security we are searching for
            IBApi.Contract contract = new IBApi.Contract();

            // Set the underlying stock symbol from the cbSymbol combobox
            contract.Symbol = cbSymbol.Text;
            // Set the Security type to STK for a Stock
            contract.SecType = "STK";
            // Use "SMART" as the general exchange
            contract.Exchange = cbMarket.Text;
            // Set the primary exchange (sometimes called Listing exchange)
            // Use either NYSE or ISLAND
            contract.PrimaryExch = "ISLAND";
            // Set the currency to USD
            contract.Currency = "USD";

            IBApi.Order order = new IBApi.Order();
            // gets the next order id from the text box
            order.OrderId = order_id;
            // gets the side of the order (BUY, or SELL)
            order.Action = side;
            // gets order type from combobox market or limit order(MKT, or LMT)
            order.OrderType = cbOrderType.Text;
            // number of shares from Quantity
            order.TotalQuantity = (decimal)Convert.ToDouble(numQuantity.Value);
            // Value from limit price
            order.LmtPrice = Convert.ToDouble(numPrice.Value);
            // checks for a stop order
            if (cbOrderType.Text == "STP")
            {
                // Stop order value from the limit textbox
                order.AuxPrice = Convert.ToDouble(numPrice.Value);
            }
            //Visible shares to the market
            order.DisplaySize = Convert.ToInt32(tbVisible.Text);
            //order.OutsideRth = cbOutsideRTH.Checked;
            order.OutsideRth = chkOutside.Checked;

            // Place the order
            ibClient.ClientSocket.placeOrder(order_id, contract, order);

            // increase the order id value
            order_id++;
            
        }

        public static List<Order> BracketOrder(int parentOrderId, string action, double quantity, double limitPrice,
            double takeProfitLimitPrice, double stopLossPrice, string order_type)
        {
            //This will be our main or "parent" order
            Order parent = new Order();
            parent.OrderId = parentOrderId;
            parent.Action = action;  // "BUY" or "SELL"
            parent.OrderType = order_type;  // "LMT", "STP", or "STP LMT"
            parent.TotalQuantity = (decimal)quantity;
            parent.LmtPrice = limitPrice;
            //The parent and children orders will need this attribute set to false to prevent accidental executions.
            //The LAST CHILD will have it set to true
            parent.Transmit = false;

            // Profit Target order
            Order takeProfit = new Order();
            takeProfit.OrderId = parent.OrderId + 1;
            takeProfit.Action = action.Equals("BUY") ? "SELL" : "BUY"; // if statement
            takeProfit.OrderType = "LMT";
            takeProfit.TotalQuantity = (decimal)quantity;
            takeProfit.LmtPrice = takeProfitLimitPrice;
            takeProfit.ParentId = parentOrderId;
            takeProfit.Transmit = false;

            // Stop loss order
            Order stopLoss = new Order();
            stopLoss.OrderId = parent.OrderId + 2;
            stopLoss.Action = action.Equals("BUY") ? "SELL" : "BUY";
            stopLoss.OrderType = "STP"; //or "STP LMT"
            //Stop trigger price
            // add stopLoss.LmtPrice here if you are going to use a stop limit order
            stopLoss.AuxPrice = stopLossPrice;
            stopLoss.TotalQuantity = (decimal)quantity;
            stopLoss.ParentId = parentOrderId;
            //In this case, the low side order will be the last child being sent. Therefore, it needs to set this attribute to true
            //to activate all its predecessors
            stopLoss.Transmit = true;
            List<Order> bracketOrder = new List<Order>();
            bracketOrder.Add(parent);
            bracketOrder.Add(takeProfit);
            bracketOrder.Add(stopLoss);
            return bracketOrder;
        }

        public void send_bracket_order(string side)
        {
            // create a new contract
            IBApi.Contract contract = new IBApi.Contract();
            // Set the underlying stock symbol from the cbSymbol combobox
            contract.Symbol = cbSymbol.Text;
            // Set the Security type to STK for a Stock
            contract.SecType = "STK";
            // Use "SMART" as the general exchange
            contract.Exchange = cbMarket.Text;
            // Set the primary exchange (sometimes called Listing exchange)
            // Use either NYSE or ISLAND
            contract.PrimaryExch = "ISLAND";
            // Set the currency to USD
            contract.Currency = "USD";

            // order_id, action (Buy or Sell), Quantity, entryPrice, targetPrice, stopLoss, order_type

            string order_type = cbOrderType.Text; // order type LMT or STP from the combobox
            string action = side; // side (BUY or SELL) passed on from the button click event
            double quantity = Convert.ToDouble(numQuantity.Value); // number of shares
            double lmtPrice = Convert.ToDouble(numPrice.Text);  // limit price from numeric up down box on the form
            double takeProfit = Convert.ToDouble(tbTakeProfit.Text);  // take profit amount from text box on the form
            double stopLoss = Convert.ToDouble(tbStopLoss.Text);  // stop loss from the text box on the form

            // side is the either buy or sell
            // calls a BracketOrder function and stores the results in a list variable called bracket
            List<Order> bracket = BracketOrder(order_id++, action, quantity, lmtPrice, takeProfit, stopLoss, order_type);
            foreach (Order o in bracket) // loops through each order in the list
                ibClient.ClientSocket.placeOrder(o.OrderId, contract, o);

            // increase the order id number by 3 so you don't use the same order id number twice,
            // and get an error
            order_id += 3;

        }

        public void AddScannerItemScanner(string strScanner)
        {
            if (this.tbLast.InvokeRequired)
            {
                SetTextCallbackScanner d = new SetTextCallbackScanner(AddScannerItemScanner);
                try
                {
                    this.Invoke(d, new object[] { strScanner });
                }
                catch (Exception e)
                {
                    Console.WriteLine("this is from _tickPrice ", e);
                }
            }
            else
            {
                string[] scanner = new string[] { strScanner };
                scanner = strScanner.Split(',');
                int position = Convert.ToInt32(scanner[1]);


                // this creates 10 rows in our datagridview to hold the list of stocks that the scanner finds
                if (position == 0)
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            dataGridView1.Rows[j].Cells[i].Value = DBNull.Value;
                        }
                    }
                }

                // adds the value for the position in the first cell in the datagrid column
                // adds one to the value so it does not show 0 in the first row
                dataGridView1.Rows[position].Cells[0].Value = position + 1;
                // adds the stock symbol in the second column (symbol)
                dataGridView1.Rows[position].Cells[1].Value = scanner[2];
                // cancels the market data for that position
                ibClient.ClientSocket.cancelMktData(position);

                // create a contract for streaming data
                IBApi.Contract contract = new IBApi.Contract();
                // Create a new TagValue List object (for API version 9.71 and later) 
                List<IBApi.TagValue> mktDataOptiones = new List<IBApi.TagValue>();
                // Set stock symbol that the scanner found
                contract.Symbol = scanner[2];
                // Set the Security type to STK for a Stock
                contract.SecType = "STK";
                // Use "SMART" as the general exchange
                contract.Exchange = "SMART";
                // Set the primary exchange (sometimes called Listing exchange)
                // Use either NYSE or ISLAND
                contract.PrimaryExch = "ISLAND";
                // Set the currency to USD
                contract.Currency = "USD";

                ibClient.ClientSocket.reqMarketDataType(1);

                ibClient.ClientSocket.reqMktData(position, contract, "", false, false, mktDataOptiones);

            }
        }

        private void lbData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void form1_load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add();
            }
            for (int i = 0; i < 10; i++)
            {
                dataGridView2.Rows.Add();
            }
            dataGridView2.Columns[3].DefaultCellStyle.Format = "#.00\\%";

            chart1.Series["Series1"].ChartType = SeriesChartType.Candlestick;  // type of chart to display the data
            chart1.Series["Series1"].BorderColor = Color.Black; // boarder color of the candlestick
            chart1.Series["Series1"].Color = Color.Black; // wick (shadow) color of the candle
            chart1.Series["Series1"].CustomProperties = "PriceDownColor=Green, PriceUpColor=Red";
            //chart1.Series["Series1"].XValueType = ChartValueType.Date;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.IsStartedFromZero = false;  // don't start from zero
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;  // don't start from zero
        }

        public void AddItemHistoricalData(string strHistoricalData)
        {
            if (this.tbLast.InvokeRequired)
            {
                SetCallbackHistoricalData d = new SetCallbackHistoricalData(AddItemHistoricalData);
                try
                {
                    this.Invoke(d, new object[] { strHistoricalData });
                }
                catch (Exception e)
                {
                    Console.WriteLine("this is from Historical Data ", e);
                }
            }
            else
            {
                //lbHistoricalData.Items.Add(strHistoricalData);
                string[] chart_val = strHistoricalData.Split(',');

                // reqId 0, Date and time 1, Open 2, High 3, Low 4, Close 5, Volume 6, Count 7, WAP 0 

                string newVal = chart_val[1].Trim();

                string OutputString = chart_val[0] + "," +
                               newVal + "," +
                               chart_val[2] + "," +
                               chart_val[3] + "," +
                               chart_val[4] + "," +
                               chart_val[5];

                // display the stock data in a list box
                lbHistoricalData.Items.Add(OutputString);
                // adds the ohlc data to the chart
                chart1.Series["Series1"].Points.AddXY(chart_val[1], chart_val[3], chart_val[4], chart_val[5], chart_val[2]);
            }

        }

        private void cbSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();
        }
        private void cbSymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void cbSymbol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbSymbol.SelectionStart = 0;
                cbSymbol.SelectionLength = cbSymbol.Text.Length;

                e.SuppressKeyPress = true;

                string name = cbSymbol.Text;


                // adds the security symbol to the dropdown list in the symbol combobox
                if (!cbSymbol.Items.Contains(name))
                {
                    cbSymbol.Items.Add(name);
                }
                cbSymbol.SelectAll();

                getData();
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        

        private void btnSell_Click(object sender, EventArgs e)
        {
            string side = "SELL";

            if (Form.ModifierKeys == Keys.Control)
            {
                send_bracket_order(side);
            }
            else
            {
                send_order(side);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            ibClient.ClientSocket.eDisconnect();
        }

        private void tbAsk_TextChanged(object sender, EventArgs e)
        {
            numPrice.Value = Convert.ToDecimal(tbAsk.Text);
        }

        private void tbBid_TextChanged(object sender, EventArgs e)
        {
            numPrice.Value = Convert.ToDecimal(tbBid.Text);
        }

        private void tbLast_TextChanged(object sender, EventArgs e)
        {
            numPrice.Value = Convert.ToDecimal(tbLast.Text);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            string side = "BUY";

            if (Form.ModifierKeys == Keys.Control)
            {
                send_bracket_order(side);
            }
            else
            {
                send_order(side);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1_counter == 0)
            {
                timer1.Stop(); // stop the timer
                //add the bid price to the limit box
                numPrice.Value = Convert.ToDecimal(tbBid.Text);
                timer1_counter = 5;// resets timer counter back to 5
            }
            timer1_counter--; // subtract 1 every time their is a tick
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            // Create a new TagValue List object (for API version 9.71) 
            //List TagValue = new List();

            // these are codes from the Scanner Parameters output.
            TagValue t1 = new TagValue("avgVolumeAbove", "10000000");
            TagValue t2 = new TagValue("priceAbove", "2");
            //TagValue t3 = new TagValue("priceBelow", "100");

            // Create a Scanner Subscription
            ScannerSubscription scsScanner = new ScannerSubscription();

            // Number of rows the scanner should retrieve (max 50)
            scsScanner.NumberOfRows = 10;
            // Scanner will look for Stocks
            scsScanner.Instrument = "STK";
            // Scanner will look at all US major stocks
            // other examples are: STK.US , STK.US.MAJOR , STK.MINOR , STK.NASDAQ , STK.NYSE , STK.AMEX
            scsScanner.LocationCode = "STK.US.MAJOR";
            // Indicate a pre-defined Market Scanner
            scsScanner.ScanCode = "TOP_PERC_GAIN";
            // Only look for Corporate stocks (not ADRs or ETFs)
            //scsScanner.StockTypeFilter = "CORP";

            //scsScanner.AboveVolume = 500000;

            //create a list to hold all the scanner parameters
            List<TagValue> TagValues = new List<TagValue> { t1, t2 };
            // Launch the Scanner
            ibClient.ClientSocket.reqScannerSubscription(87, scsScanner, null, TagValues);

            // will display all the scanner parameter in the console in xml format
            //ibClient.ClientSocket.reqScannerParameters();
        }

        private void btnStopScan_Click(object sender, EventArgs e)
        {
            // cancels scanner data subscription
            ibClient.ClientSocket.cancelScannerSubscription(87);

            // cancels each symbol streaming data in the scanner datagridview
            for (int i = 0; i < 9; i++)
            {
                ibClient.ClientSocket.cancelMktData(i);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; //check if row index is not selected
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(1))
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                    cbSymbol.Text = Convert.ToString(dataGridView1.CurrentCell.Value);
            getData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void AddTickSizeItem(int tickerId,
                                    int field,
                                    int size)
        {
            if (this.tbLast.InvokeRequired)
            {
                SetTextCallbackTickSize d = new SetTextCallbackTickSize(AddTickSizeItem);
                try
                {
                    this.Invoke(d, new object[] { tickerId, field, size });
                }
                catch (Exception e)
                {
                    Console.WriteLine("this is from _tickPrice ", e);
                }
            }
            else
            {

                switch (tickerId)
                {
                    case 10:
                        if (field == 8)
                        {
                            int mySize = size * 100;
                            dataGridView2[2, 0].Value = mySize.ToString();
                            break;
                        }
                        break;
                    case 11:
                        if (field == 8)
                        {
                            int mySize = size * 100;
                            dataGridView2[2, 1].Value = mySize.ToString();
                            break;
                        }
                        break;
                    case 12:
                        if (field == 8)
                        {
                            int mySize = size * 100;
                            dataGridView2[2, 2].Value = mySize.ToString();
                            break;
                        }
                        break;
                    case 13:
                        if (field == 8)
                        {
                            int mySize = size * 100;
                            dataGridView2[2, 3].Value = mySize.ToString();
                            break;
                        }
                        break;
                    case 14:
                        if (field == 8)
                        {
                            int mySize = size * 100;
                            dataGridView2[2, 4].Value = mySize.ToString();
                            break;
                        }
                        break;
                    case 15:
                        if (field == 8)
                        {
                            int mySize = size * 100;
                            dataGridView2[2, 5].Value = mySize.ToString();
                            break;
                        }
                        break;
                    case 16:
                        if (field == 8)
                        {
                            int mySize = size * 100;
                            dataGridView2[2, 6].Value = mySize.ToString();
                            break;
                        }
                        break;
                    case 17:
                        if (field == 8)
                        {
                            int mySize = size * 100;
                            dataGridView2[2, 7].Value = mySize.ToString();
                            break;
                        }
                        break;
                    case 18:
                        if (field == 8)
                        {
                            int mySize = size * 100;
                            dataGridView2[2, 8].Value = mySize.ToString();
                            break;
                        }
                        break;
                    case 19:
                        if (field == 8)
                        {
                            int mySize = size * 100;
                            dataGridView2[2, 9].Value = mySize.ToString();
                            break;
                        }
                        break;
                }
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; //check if row index is not selected (The index must not be negative)
            if (dataGridView2.CurrentCell.ColumnIndex.Equals(0)) // indicates which column you get the info from 0 = first column
                if (dataGridView2.CurrentCell != null && dataGridView2.CurrentCell.Value != null)
                    cbSymbol.Text = Convert.ToString(dataGridView2.CurrentCell.Value);
            getData(); // requests the data for the symbol in the order form
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int loc = dataGridView2.Rows[e.RowIndex].Index;

            dataGridView2[1, loc].Value = null;
            dataGridView2[2, loc].Value = null;
            dataGridView2[3, loc].Value = null;
            dataGridView2[4, loc].Value = null;

            if (dataGridView2.CurrentCell != null && dataGridView2.CurrentCell.Value != null)
            {
                int rowIndex = dataGridView2.Rows[e.RowIndex].Index + 10;

                ibClient.ClientSocket.cancelMktData(rowIndex);

                string symbol = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // create a contract for streaming data
                IBApi.Contract contract = new IBApi.Contract();
                // Create a new TagValueList object (for API version 9.71 and later) 
                List<IBApi.TagValue> mktDataOptiones = new List<IBApi.TagValue>();
                // Set stock symbol that the scanner found
                contract.Symbol = symbol;
                // Set the Security type to STK for a Stock
                contract.SecType = "STK";
                // Use "SMART" as the general exchange
                contract.Exchange = "SMART";
                // Set the primary exchange (sometimes called Listing exchange)
                // Use either NYSE or ISLAND
                contract.PrimaryExch = "ISLAND";
                // Set the currency to USD
                contract.Currency = "USD";

                ibClient.ClientSocket.reqMarketDataType(1);

                ibClient.ClientSocket.reqMktData(rowIndex, contract, "", false, false, mktDataOptiones);
            }
        }
        private void tabControl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[3].Value != null)
            {
                try
                {
                    double change_percent = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
                    change_percent = change_percent * 100;
                    string final_percent = change_percent.ToString("#.00\\%");

                    if (change_percent > 0)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[3].Style.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (change_percent < 0)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[3].Style.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch
                {

                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbHistoricalData.Items.Count; i++)
            {
                lbHistoricalData.SetSelected(i, true);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (object row in lbHistoricalData.SelectedItems)
                {
                    sb.Append(row.ToString());
                    sb.AppendLine();
                }
                sb.Remove(sb.Length - 1, 1); // Just to avoid copying last empty row
                Clipboard.SetData(System.Windows.Forms.DataFormats.Text, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelLast_Click(object sender, EventArgs e)
        {
            // Create an OrderCancel object with necessary parameters
            OrderCancel orderCancel = new OrderCancel();
            // cancels last order
            ibClient.ClientSocket.cancelOrder(order_id - 1, orderCancel);
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            // cancels all the orders
            ibClient.ClientSocket.reqGlobalCancel();
        }
    }
}
