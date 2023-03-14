using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace JSONparseClass
{
    public class ParseJSONfile
    {
        public static string ParseDevice(string path)
        {
            StringBuilder parsed = new StringBuilder();

            
            Device device;
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                device = (Device)serializer.Deserialize(file, typeof(Device));
            }

           
            parsed.AppendLine($"Device Name: {device.DeviceName}");
            parsed.AppendLine($"Manufacturer: {device.Manufacturer}");
            parsed.AppendLine($"Part Number: {device.PartNumber}");
            parsed.AppendLine($"Serial Number: {device.SerialNumber}");
            parsed.AppendLine($"Product Name: {device.ProductName}");
            parsed.AppendLine($"Vendor Part Number: {device.VendorPartNumber}");
            parsed.AppendLine($"Vendor Serial Number: {device.VendorSerialNumber}");
            parsed.AppendLine($"License ID: {device.LicenseId}");
            parsed.AppendLine($"Chassis Wwn: {device.ChassisWwn}");
            parsed.AppendLine($"Collector Date: {device.CollectorDate}");
            parsed.AppendLine();

            
            parsed.AppendLine("Ports:");
            int portNumber = 1;
            foreach (Port port in device.Ports)
            {
                parsed.AppendLine($"{portNumber}.");
                parsed.AppendLine($"Wwpn: {port.Wwpn}");
                parsed.AppendLine($"Wwnn: {port.Wwnn}");
                parsed.AppendLine($"Domain ID: {port.DomainId}");
                parsed.AppendLine($"Fc ID: {port.FcId}");
                parsed.AppendLine($"Port Name: {port.PortName}");
                parsed.AppendLine($"Port Number: {port.PortNumber}");
                parsed.AppendLine($"Firmware Version: {port.FirmwareVersion}");
                parsed.AppendLine($"Serial Number: {port.SerialNumber}");
                parsed.AppendLine();
                portNumber++;
            }

            return parsed.ToString();
        }
    }

}

