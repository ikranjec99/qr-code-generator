using Microsoft.Extensions.Logging;
using QRCodeGenerator.Core.Constants;

namespace QRCodeGenerator.Core.Extensions;

public static class LoggingEventExtensions
{
    public static EventId ToEventId(this LoggingEvent disposableDomainDetectorEvent)
        => new EventId((int)disposableDomainDetectorEvent, disposableDomainDetectorEvent.ToString());
}