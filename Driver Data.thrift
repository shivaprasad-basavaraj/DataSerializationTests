union Session {
  1: string name,
  2: i32 id,
}

struct DeviceProperties {
  1: string name,
  2: string model,
  3: string vendor,
  4: string serial_number,
}

struct EnumerateDevicesRequest {}

struct EnumerateDevicesResponse {
  1: list<DeviceProperties> devices,
}

struct ReserveRequest {
  // client defined string representing a set of reservable resources
  1: string reservation_id,
  // client defined identifier for a specific client
  2: string client_id,
}

struct ReserveResponse {
  1: bool is_reserved,
}

struct IsReservedByClientRequest {
  // client defined string representing a set of reservable resources
  1: string reservation_id,
  // client defined identifier for a specific client
  2: string client_id,
}

struct IsReservedByClientResponse {
  1: bool is_reserved,
}

struct UnreserveRequest {
  // client defined string representing a set of reservable resources
  1: string reservation_id,
  // client defined identifier for a specific client
  2: string client_id,
}

struct UnreserveResponse {
  1: bool is_unreserved,
}

struct ResetServerRequest {}

struct ResetServerResponse {
  1: bool is_server_reset,
}