export type VisitorLog = {
  id: number;
  visitorName: string;
  purpose: string;
  timestamp: string;
  status: 'Pending' | 'Approved' | 'Denied';
  residentName: string;
  residentPhone: string;
  apartmentBlock: string;
};

export type VisitorCheckInPayload = {
  visitorName: string;
  purpose: string;
  residentId: number;
};
