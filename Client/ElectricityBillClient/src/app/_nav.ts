import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  // {
  //   title: true,
  //   name: 'Theme'
  // },
  {
    name: 'User',
    url: '/User/View',
    icon: 'icon-user-following'
  },
  {
    name: 'Role',
    url: '/Role/View',
    icon: 'icon-book-open'
  },
  {
    name: 'User Role',
    url: '/UserRole/View',
    icon: 'icon-speech ',
  },
  {
    name: 'Meter',
    url: '/Meter/View',
    icon: 'icon-speedometer'
  },
  {
    name: 'Zone',
    url: '/Zone/View',
    icon: 'icon-location-pin'
  },
  {
    name: 'ZoneAssign',
    url: '/ZoneAssign/View',
    icon: 'icon-location-pin'
  },
  {
    name: 'Customer',
    url: '/Customer/View',
    icon: 'icon-user'
  },
  {
    name: 'Pending Customer',
    url: '/Customer/PendingCustomer',
    icon: 'icon-user-unfollow'
  },

  {
    name: 'Billl',
    url: '/Bill/View',
    icon: 'icon-wallet'
  },
  {
    name: 'PaymentHistory',
    url: '/Bill/PaimentHistory',
    icon: 'icon-wallet'
  },

  
  {
    name: 'Card',
    url: '/Card/View',
    icon: 'icon-credit-card'
  },
  {
    name: 'MobileBanking',
    url: '/MobileBanking/View',
    icon: 'icon-user'
  },
  
  {
    name: 'Assign Meter',
    url: '/AssignMeter/View',
    icon: 'icon-list'
  },
  {
    name: 'Unit Price',
    url: '/UnitPrice/View',
    icon: 'icon-list'
  },
  {
    name: 'MeterReading',
    url: '/MeterReading/View',
    icon: 'icon-calculator'
  },
  {
    name: 'ChangePassword',
    url: '/ChangePassword',
    icon: 'icon-key'
  },

];
export const navItemsCoOrdinators: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    name: 'Meter',
    url: '/Meter/View',
    icon: 'icon-speedometer'
  },
  {
    name: 'Pending Customer',
    url: '/Customer/PendingCustomer',
    icon: 'icon-user'
  },

  {
    name: 'Assign Meter',
    url: '/AssignMeter/View',
    icon: 'icon-list'
  },
  {
    name: 'Unit Price',
    url: '/UnitPrice/View',
    icon: 'icon-list'
  },
  {
    name: 'ChangePassword',
    url: '/ChangePassword',
    icon: 'icon-key'
  },



];

export const navItemsMeterReader: INavData[] = [
 
  // {
  //   title: true,
  //   name: 'Theme'
  // },

  
 
 
  {
    name: 'Customer Meter',
    url: '/AssignMeter/CustomerMeter',
    icon: 'icon-list'
  },
  
  
  {
    name: 'MeterReading',
    url: '/MeterReading/View',
    icon: 'icon-speedometer'
  },
  {
    name: 'ChangePassword',
    url: '/ChangePassword',
    icon: 'icon-key'
  },


];

