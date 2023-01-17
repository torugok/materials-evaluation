import { DateTime } from 'luxon';

export function convertToLocaleString(isoStringUtc: string): string {
  return DateTime.fromISO(isoStringUtc).toLocal().toFormat('dd/MM/yyyy HH:mm');
}
