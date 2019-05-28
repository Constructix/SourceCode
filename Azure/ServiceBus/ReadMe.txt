Demostrates the use of Azure Service Bus

Notes:
To  put messages on queue. Make sure that the queue exists in Azure
1. Log in to Azure Portal
2. Confirm Ordersqueue exist in Azure
3. Make sure SubmitOrdersToServiceBusDemo is one of the startup projects.

Once done, SubmitOrdersToServiceBusDemo will create test orders to be put onto the  ordersQueue.

Use ReceiveORdersFromServiceBusSDemo to retrieve the orders. The number of items in the queue, should be pulled of the ordersqueue and displayed to the console and or to the test log file.
